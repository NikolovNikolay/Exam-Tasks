using System;
using System.Linq;
using System.Text;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using System.Reflection;
using System.Collections.Generic;

namespace HTMLRenderer
{
    public interface IElement
    {
        string Name { get; }
        string TextContent { get; set; }
        IEnumerable<IElement> ChildElements { get; }
        void AddElement(IElement element);
        void Render(StringBuilder output);
        string ToString();
    }

    public interface ITable : IElement
    {
        int Rows { get; }
        int Cols { get; }
        IElement this[int row, int col] { get; set; }
    }

    public interface IElementFactory
    {
        IElement CreateElement(string name);
        IElement CreateElement(string name, string content);
        ITable CreateTable(int rows, int cols);
    }

    public class HTMLElementFactory : IElementFactory
    {
        public IElement CreateElement(string name)
        {
            return new HTMLElement(name);
        }

        public IElement CreateElement(string name, string content)
        {
            return new HTMLElement(name, content);
        }

        public ITable CreateTable(int rows, int cols)
        {
            return new HTMLTable(rows, cols);
        }
    }

    public class HTMLElement : IElement
    {
        private IList<IElement> childElements;

        public HTMLElement ( string name)
        {
            this.Name = name;
            this.childElements = new List<IElement>();
        }

        public HTMLElement(string name, string content) : this(name)
        {
            this.TextContent = content;
        }
        public virtual string Name { get; private set; }

        public virtual string TextContent { get; set; }

        public IEnumerable<IElement> ChildElements { get { return this.ChildElements; } }

        public void AddElement(IElement element)
        {
            this.childElements.Add(element);
        }

        public void Render(StringBuilder output)
        {
            if(this.Name != null)
            {
                output.Append('<');
                output.Append(this.Name);
                output.Append('>');
            }
            if(this.TextContent != null)
            {
                output.Append(HTMLPreworker(this.TextContent));
            }
            for (int i = 0; i < this.childElements.Count; i++)
            {
                this.childElements[i].Render(output);
            }
            if(this.Name != null)
            {
                output.Append("</");
                output.Append(this.Name);
                output.Append('>');
            }
        }

        protected string HTMLPreworker(string content)
        {
            var result = new StringBuilder();

            for (int i = 0; i < content.Length; i++)
            {
                if(content[i] == '<')
                {
                    result.Append("&lt;");
                }
                else if(content[i] == '>')
                {
                    result.Append("&gt;");
                }
                else if(content[i] == '&')
                {
                    result.Append("&amp;");
                }
                else
                {
                    result.Append(content[i]);
                }                
            }
            return result.ToString();
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            this.Render(result);
            return result.ToString();
        }
    }

    public class HTMLTable : HTMLElement,  ITable
    {
        public int Rows { get; private set; }
        public int Cols { get; private set; }
        private IElement[,] elements;

        public HTMLTable(int row, int col) : base("table")
        {
            this.Rows = row;
            this.Cols = col;
            this.elements = new IElement[row, col];
        }
        public IElement this[int row, int col]
        {
            get
            {
                return this.elements[row, col];
            }
            set
            {
                this.elements[row, col] = value;
            }
        }

        public void Render(StringBuilder output)
        {
            output.Append("<table>");
            for (int row = 0; row < this.Rows; row++)
            {
                output.Append("<tr>");
                for (int col = 0; col < this.Cols; col++)
                {
                    output.Append("<td>");
                    this.elements[row, col].Render(output);
                    output.Append("</td>");
                }
                output.Append("</tr>");
            }
            output.Append("</table>");
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            this.Render(result);
            return result.ToString();
        }
    }


    public class HTMLRendererCommandExecutor
    {
        static void Main()
        {
            string csharpCode = ReadInputCSharpCode();
            CompileAndRun(csharpCode);
        }

        private static string ReadInputCSharpCode()
        {
            StringBuilder result = new StringBuilder();
            string line;
            while ((line = Console.ReadLine()) != "")
            {
                result.AppendLine(line);
            }
            return result.ToString();
        }

        static void CompileAndRun(string csharpCode)
        {
            // Prepare a C# program for compilation
            string[] csharpClass =
            {
                @"using System;
                  using HTMLRenderer;

                  public class RuntimeCompiledClass
                  {
                     public static void Main()
                     {"
                        + csharpCode + @"
                     }
                  }"
            };

            // Compile the C# program
            CompilerParameters compilerParams = new CompilerParameters();
            compilerParams.GenerateInMemory = true;
            compilerParams.TempFiles = new TempFileCollection(".");
            compilerParams.ReferencedAssemblies.Add("System.dll");
            compilerParams.ReferencedAssemblies.Add(Assembly.GetExecutingAssembly().Location);
            CSharpCodeProvider csharpProvider = new CSharpCodeProvider();
            CompilerResults compile = csharpProvider.CompileAssemblyFromSource(
                compilerParams, csharpClass);

            // Check for compilation errors
            if (compile.Errors.HasErrors)
            {
                string errorMsg = "Compilation error: ";
                foreach (CompilerError ce in compile.Errors)
                {
                    errorMsg += "\r\n" + ce.ToString();
                }
                throw new Exception(errorMsg);
            }

            // Invoke the Main() method of the compiled class
            Assembly assembly = compile.CompiledAssembly;
            Module module = assembly.GetModules()[0];
            Type type = module.GetType("RuntimeCompiledClass");
            MethodInfo methInfo = type.GetMethod("Main");
            methInfo.Invoke(null, null);
        }
    }
}
