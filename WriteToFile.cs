using System.Text;

namespace Testing
{
    //Inherit from from textWriter class 
    class WriteToFile : TextWriter
    {
        private TextWriter[] writers;

        // constructor 
        public WriteToFile(params TextWriter[] writers)
        {
            this.writers = writers;
        }


        // override TextWrirer methods
        public override Encoding Encoding
        {
            get { return writers[0].Encoding; }
        }
        public override void Write(char value)
        {
            foreach (TextWriter writer in writers)
            {
                writer.Write(value);
            }
        }
        public override void Write(string value)
        {
            foreach (TextWriter writer in writers)
            {
                writer.Write(value);
            }
        }
        public override void WriteLine(string value)
        {
            foreach (TextWriter writer in writers)
            {
                writer.WriteLine(value);
            }
        }
    }
}
