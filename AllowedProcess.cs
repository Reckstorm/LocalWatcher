namespace ProcessAdmin_19._08
{
    internal class AllowedProcess
    {
        public string ProcessName { get; set; }
        private object locker { get; set; } = new object();

        private TimeOnly _blockStartTime;

        public TimeOnly BlockStartTime
        {
            get { lock(locker) return _blockStartTime; }
            set { lock (locker) _blockStartTime = value; }
        }

        private TimeOnly _blockEndtTime;

        public TimeOnly BlockEndtTime
        {
            get { lock (locker) return _blockEndtTime; }
            set { lock (locker) _blockEndtTime = value; }
        }

        public AllowedProcess()
        {
            BlockStartTime = new TimeOnly(00, 00, 00, 000);
            BlockEndtTime = new TimeOnly(23, 59, 59, 999);
            ProcessName = string.Empty;
        }

        public AllowedProcess(string proc)
        {
            BlockStartTime = new TimeOnly(00, 00, 00, 000);
            BlockEndtTime = new TimeOnly(23, 59, 59, 999);
            ProcessName = proc;
        }

        public AllowedProcess(string proc, TimeOnly blockStartTime, TimeOnly blockEndtTime)
        {
            ProcessName = proc;
            BlockStartTime = blockStartTime;
            BlockEndtTime = blockEndtTime;
        }
    }
}
