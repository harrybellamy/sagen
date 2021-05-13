using System;

namespace Sagen.Core.Config
{
    public class ProcessorConfig
    {
        public ProcessorConfig(ISource source, ISink sink)
        {
            Source = source;
            Sink = sink;
        }

        public ISource Source { get; }

        public ISink Sink { get; }
    }
}
