using System;

namespace Sagen.Core.Config
{
    public class ProcessorConfig
    {
        public ProcessorConfig(ISink source, ISink sink)
        {
            Source = source;
            Sink = sink;
        }

        public ISink Source { get; }

        public ISink Sink { get; }
    }
}
