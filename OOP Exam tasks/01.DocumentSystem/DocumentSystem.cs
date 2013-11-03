using System;
using System.Collections.Generic;
using System.Text;

public interface IDocument
{
    string Name { get; }
    string Content { get; }
    void LoadProperty(string key, string value);
    void SaveAllProperties(IList<KeyValuePair<string, object>> output);
    string ToString();
}

public interface IEditable
{
    void ChangeContent(string newContent);
}

public interface IEncryptable
{
    bool IsEncrypted { get; }
    void Encrypt();
    void Decrypt();
}

public class DocumentSystem
{
    private static IList<IDocument> documents = new List<IDocument>();
    static void Main()
    {
        IList<string> allCommands = ReadAllCommands();
        ExecuteCommands(allCommands);
    }

    private static IList<string> ReadAllCommands()
    {
        List<string> commands = new List<string>();
        while (true)
        {
            string commandLine = Console.ReadLine();
            if (commandLine == "")
            {
                // End of commands
                break;
            }
            commands.Add(commandLine);
        }
        return commands;
    }

    private static void ExecuteCommands(IList<string> commands)
    {
        foreach (var commandLine in commands)
        {
            int paramsStartIndex = commandLine.IndexOf("[");
            string cmd = commandLine.Substring(0, paramsStartIndex);
            int paramsEndIndex = commandLine.IndexOf("]");
            string parameters = commandLine.Substring(
                paramsStartIndex + 1, paramsEndIndex - paramsStartIndex - 1);
            ExecuteCommand(cmd, parameters);
        }
    }

    private static void ExecuteCommand(string cmd, string parameters)
    {
        string[] cmdAttributes = parameters.Split(
            new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
        if (cmd == "AddTextDocument")
        {
            AddTextDocument(cmdAttributes);
        }
        else if (cmd == "AddPDFDocument")
        {
            AddPdfDocument(cmdAttributes);
        }
        else if (cmd == "AddWordDocument")
        {
            AddWordDocument(cmdAttributes);
        }
        else if (cmd == "AddExcelDocument")
        {
            AddExcelDocument(cmdAttributes);
        }
        else if (cmd == "AddAudioDocument")
        {
            AddAudioDocument(cmdAttributes);
        }
        else if (cmd == "AddVideoDocument")
        {
            AddVideoDocument(cmdAttributes);
        }
        else if (cmd == "ListDocuments")
        {
            ListDocuments();
        }
        else if (cmd == "EncryptDocument")
        {
            EncryptDocument(parameters);
        }
        else if (cmd == "DecryptDocument")
        {
            DecryptDocument(parameters);
        }
        else if (cmd == "EncryptAllDocuments")
        {
            EncryptAllDocuments();
        }
        else if (cmd == "ChangeContent")
        {
            ChangeContent(cmdAttributes[0], cmdAttributes[1]);
        }
        else
        {
            throw new InvalidOperationException("Invalid command: " + cmd);
        }
    }

    private static void AddTextDocument(string[] attributes)
    {
        AddDocument(new TextDocument(), attributes);
    }

    private static void AddPdfDocument(string[] attributes)
    {
        AddDocument(new PDFDocument(), attributes);
    }

    private static void AddWordDocument(string[] attributes)
    {
        AddDocument(new WordDocument(), attributes);
    }

    private static void AddExcelDocument(string[] attributes)
    {
        AddDocument(new ExcelDocument(), attributes);
    }

    private static void AddAudioDocument(string[] attributes)
    {
        AddDocument(new AudioDocument(), attributes);
    }

    private static void AddVideoDocument(string[] attributes)
    {
        AddDocument(new VideoDocument(), attributes);
    }

    private static void AddDocument(IDocument document, string[] attributes)
    {
        foreach (var attribute in attributes)
        {
            string[] keyAndValue = attribute.Split('=');
            string key = keyAndValue[0];
            string value = keyAndValue[1];
            document.LoadProperty(key, value);
        }

        if(document.Name != null)
        {
            documents.Add(document);
            Console.WriteLine("Document added: {0}", document.Name);
        }
        else
        {
            Console.WriteLine("Document has no name");
        }
    }

    private static void ListDocuments()
    {
        if(documents.Count <= 0)
        {
            Console.WriteLine("No documents found");           
        }
        else
        {
            foreach (var doc in documents)
            {
                if(doc is IEncryptable && ((IEncryptable)(doc)).IsEncrypted)
                {
                    Console.WriteLine("{0}[encrypted]",doc.GetType().Name);
                }
                else
                {
                    Console.WriteLine(doc);
                }
            }
        }
    }

    private static void EncryptDocument(string name)
    {
        int counter = 0;
        foreach (var doc in documents)
        {
            if(doc.Name == name)
            {
                counter++;
                if(doc is IEncryptable)
                {
                    ((IEncryptable)(doc)).Encrypt();
                    Console.WriteLine("Document encrypted: {0}", doc.Name);
                }
                else
                {
                    Console.WriteLine("Document does not support encryption: {0}", doc.Name);
                }
            }
        }
        if(counter == 0)
        {
            Console.WriteLine("Document not found: {0}", name);
        }
    }

    private static void DecryptDocument(string name)
    {
        int counter = 0;
        foreach (var doc in documents)
        {
            if (doc.Name == name)
            {
                counter++;
                if (doc is IEncryptable)
                {
                    ((IEncryptable)(doc)).Decrypt();
                    Console.WriteLine("Document decrypted: {0}", doc.Name);
                }
                else
                {
                    Console.WriteLine("Document does not support decryption: {0}", doc.Name);
                }
            }
        }
        if (counter == 0)
        {
            Console.WriteLine("Document not found: {0}", name);
        }
    }

    private static void EncryptAllDocuments()
    {
        int counter = 0;
        foreach (var doc in documents)
        {
            if(doc is IEncryptable)
            {
                counter++;
                ((IEncryptable)(doc)).Encrypt();
            }
        }

        if(counter > 0)
        {
            Console.WriteLine("All documents encrypted");
        }
        else
        {
            Console.WriteLine("No encryptable documents found");
        }
    }

    private static void ChangeContent(string name, string content)
    {
        bool docFound = false;

        foreach (var doc in documents)
        {
            if(doc.Name == name)
            {
                if (doc is IEditable)
                {
                    ((IEditable)(doc)).ChangeContent(content);
                    Console.WriteLine("Document content changed: {0}", doc.Name);
                    docFound = true;
                }
                else
                {
                    Console.WriteLine("Document is not editable: {0}", doc.Name);
                    docFound = true;
                }                
            }
        }

        if (!docFound)
        {
            Console.WriteLine("Document not found: " + name);
        }
    }
}


    public class Document : IDocument
    {
        public string Name { get; protected set; }

        public string Content { get; protected set; }

        public virtual void LoadProperty(string key, string value)
        {
            if(key == "name")
            {
                this.Name = value;
            }
            else if(key == "content")
            {
                this.Content = value;
            }
            //else
            //{
            //    throw new ArgumentException("Key {0} not found", key);
            //}
        }

        public virtual void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            output.Add(new KeyValuePair<string, object>("name", this.Name));
            output.Add(new KeyValuePair<string, object>("content", this.Content));
        }

        public override string ToString()
        {
            List<KeyValuePair<string, object>> properties = new List<KeyValuePair<string, object>>();
            this.SaveAllProperties(properties);
            properties.Sort((a, b) => a.Key.CompareTo(b.Key));

            var sb = new StringBuilder();
            sb.Append(this.GetType().Name);
            sb.Append('[');
            bool first = true;
            foreach (var prop in properties)
            {
                if (prop.Value != null)
                {
                    if(!first)
                    {
                        sb.Append(';');
                    }
                    sb.AppendFormat("{0}={1}", prop.Key, prop.Value);
                    first = false;
                }
            }
            sb.Append(']');
            return sb.ToString();
        }
    }

    public abstract class BinaryDocument : Document
    {
        public ulong? Size { get; set; }

        public override void LoadProperty(string key, string value)
        {
            if(key == "size")
            {
                this.Size = ulong.Parse(value);
            }
            else
            base.LoadProperty(key, value);
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            base.SaveAllProperties(output);
            output.Add(new KeyValuePair<string, object>("size", this.Size));
        }
    }

    public class TextDocument : Document, IEditable
    {
        public string Charset { get; set; }

        public void ChangeContent(string newContent)
        {
            this.Content = newContent;
        }

        public override void LoadProperty(string key, string value)
        {
            if(key == "charset")
            {
                this.Charset = value;
            }
            else
            {
                base.LoadProperty(key, value);
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            base.SaveAllProperties(output);
            output.Add(new KeyValuePair<string, object>("charset", this.Charset));
        }
    }

    public class PDFDocument : EncryptableBinaryDocuments
    {
        public int? NumberOfPages { get; set; }
        public override void LoadProperty(string key, string value)
        {
            if(key == "pages")
            {
                this.NumberOfPages = int.Parse(value);
            }
            else
            {
                base.LoadProperty(key,value);
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            base.SaveAllProperties(output);
            output.Add(new KeyValuePair<string, object>("pages", this.NumberOfPages));
        }
    }

    public abstract class OfficeDocument : EncryptableBinaryDocuments
    {
        public string Version { get; set; }

        public override void LoadProperty(string key, string value)
        {
            if (key == "version")
            {
                this.Version = value;
            }
            else
            {
                base.LoadProperty(key, value);
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            base.SaveAllProperties(output);
            output.Add(new KeyValuePair<string, object>("version", this.Version));
        }
    }

    public class MultimediaDocumet : BinaryDocument
    {
        public int? Length { get; set; }

        public override void LoadProperty(string key, string value)
        {
            if(key == "length")
            {
                this.Length = int.Parse(value);
            }
            else
            base.LoadProperty(key, value);
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            base.SaveAllProperties(output);
            output.Add(new KeyValuePair<string, object>("length", this.Length));
        }
    }

    public class AudioDocument : MultimediaDocumet
    {
        public int? SampleRateHZ { get; set; }

        public override void LoadProperty(string key, string value)
        {
            if (key == "samplerate")
            {
                this.SampleRateHZ = int.Parse(value);
            }
            else
                base.LoadProperty(key, value);
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            base.SaveAllProperties(output);
            output.Add(new KeyValuePair<string, object>("samplerate", this.SampleRateHZ));
        }
    }

    public class VideoDocument : MultimediaDocumet
    {
        public int? FrameRate { get; set; }

        public override void LoadProperty(string key, string value)
        {
            if (key == "framerate")
            {
                this.FrameRate = int.Parse(value);
            }
            else
                base.LoadProperty(key, value);
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            base.SaveAllProperties(output);
            output.Add(new KeyValuePair<string, object>("framerate", this.FrameRate));
        }
    }

    public class EncryptableBinaryDocuments : BinaryDocument, IEncryptable
    {
        private bool isEncrypted = false;
        public bool IsEncrypted
        {
            get { return this.isEncrypted; }
        }

        public void Encrypt()
        {
            this.isEncrypted = true;
        }

        public void Decrypt()
        {
            this.isEncrypted = false;
        }
    }

    public class WordDocument : OfficeDocument, IEditable
    {

        public int? NumberOfCharacters { get; set; }

        public override void LoadProperty(string key, string value)
        {
            if (key == "chars")
            {
                this.NumberOfCharacters = int.Parse(value);
            }
            else
                base.LoadProperty(key, value);
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            base.SaveAllProperties(output);
            output.Add(new KeyValuePair<string, object>("chars", this.NumberOfCharacters));
        }
        public void ChangeContent(string newContent)
        {
            this.Content = newContent;
        }
    }

    public class ExcelDocument : OfficeDocument
    {
        public int? NumberOfRows { get; set; }

        public int? NumberOfColumns { get; set; }

        public override void LoadProperty(string key, string value)
        {
            if (key == "rows")
            {
                this.NumberOfRows = int.Parse(value);
            }
            else if(key == "cols")
            {
                this.NumberOfColumns = int.Parse(value);
            }
            else
                base.LoadProperty(key, value);
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            base.SaveAllProperties(output);
            output.Add(new KeyValuePair<string, object>("cols", this.NumberOfColumns));
            output.Add(new KeyValuePair<string, object>("rows", this.NumberOfRows));
        }
        public void ChangeContent(string newContent)
        {
            this.Content = newContent;
        }
    }