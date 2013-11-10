using System;
using System.Linq;
using System.Text;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using System.Reflection;
using System.Collections.Generic;

namespace SoftwareAcademy
{
    public interface ITeacher
    {
        string Name { get; set; }
        void AddCourse(ICourse course);
        string ToString();
    }

    public interface ICourse
    {
        string Name { get; set; }
        ITeacher Teacher { get; set; }
        void AddTopic(string topic);
        string ToString();
    }

    public interface ILocalCourse : ICourse
    {
        string Lab { get; set; }
    }

    public interface IOffsiteCourse : ICourse
    {
        string Town { get; set; }
    }

    public interface ICourseFactory
    {
        ITeacher CreateTeacher(string name);
        ILocalCourse CreateLocalCourse(string name, ITeacher teacher, string lab);
        IOffsiteCourse CreateOffsiteCourse(string name, ITeacher teacher, string town);
    }

    public class CourseFactory : ICourseFactory
    {
        public ITeacher CreateTeacher(string name)
        {
            return new Teacher(name);
        }

        public ILocalCourse CreateLocalCourse(string name, ITeacher teacher, string lab)
        {
            return new LocalCourse(name, teacher, lab);
        }

        public IOffsiteCourse CreateOffsiteCourse(string name, ITeacher teacher, string town)
        {
            return new OffsiteCourse(name, teacher, town);
        }
    }

    public class Teacher : ITeacher
    {
        private string name;
        private IList<ICourse> courses;

        public Teacher(string name)
        {
            this.name = name;
        }
        
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        

        public void AddCourse(ICourse course)
        {
            if (this.courses == null)
            {
                this.courses = new List<ICourse>(); 
            }
            this.courses.Add(course);
        }

        public override string ToString()
        {
            if(this.courses == null)
            {
                string result = "Teacher: Name=" + this.Name;
                return result;
            }
            else
            {
                var result = new StringBuilder();
                result.AppendFormat("Teacher: Name={0}; Courses=[", this.Name);
                foreach (var course in this.courses)
                {
                    result.AppendFormat("{0}, ", course.Name);
                }
                result.Remove(result.Length - 2, 2);
                result.Append("]");

                return result.ToString();
            }
        }
    }

    public class Course : ICourse
    {
        protected string name;
        protected string lab;
        protected string town;
        protected ITeacher teacher;
        protected IList<string> topics;

        public Course(string name, ITeacher teacher, string lab)
        {
            this.name = name;
            this.teacher = teacher;
            this.lab = lab;
            //if (teacher != null)
            //{
            //    this.teacher.AddCourse(this); 
            //}
        }

        public Course(string name, ITeacher teacher) : this(name,teacher,null)
        {
        }       

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public ITeacher Teacher
        {
            get { return this.teacher; }
            set { this.teacher = value; }
        }

        public void AddTopic(string topic)
        {
            if(this.topics == null)
            {
                this.topics = new List<string>();
            }
            this.topics.Add(topic);
        }

        public string Town
        {
            get { return this.town; }
            set { this.town = value; }
        }

        public string Lab
        {
            get { return this.lab; }
            set { this.lab = value; }
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.Append(this.GetType().Name+": ");
            result.AppendFormat("Name={0};", this.name);
            if(this.teacher != null)
            {
                result.AppendFormat(" Teacher={0};", this.teacher.Name);
            }
            if(this.topics != null)
            {
                result.Append(" Topics=[");
                foreach (var topic in topics)
                {
                    result.AppendFormat("{0}, ",topic);
                }
                result.Length -= 2;
                result.Append("];");
            }
            if(this.lab!= null)
            {
                result.AppendFormat(" Lab={0};", this.lab);
            }
            if(this.town != null)
            {
                result.AppendFormat(" Town={0};", this.town);
            }

            result.Length--;
            return result.ToString();
        }
    }

    public class OffsiteCourse :Course, ICourse, IOffsiteCourse
    {
        public OffsiteCourse(string name, ITeacher teacher, string town) : base(name, teacher, town)
        {
            this.town = town;
            this.lab = null;
        }
       
        public OffsiteCourse(string name, ITeacher teacher)
            : base(name, teacher, null)
        {
        }        
    }

    public class LocalCourse :Course, ICourse, ILocalCourse
    {
        public LocalCourse(string name, ITeacher teacher, string lab) : base(name,teacher,lab)
        {
            this.lab = lab;
            this.town = null;
        }

        public LocalCourse(string name, ITeacher teacher) : base(name,teacher,null)
        {
        }
    }


    public class SoftwareAcademyCommandExecutor
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
                  using SoftwareAcademy;

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

