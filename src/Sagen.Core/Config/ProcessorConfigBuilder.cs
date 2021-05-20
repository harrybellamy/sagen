using System;

namespace Sagen.Core.Config
{
    /// <summary>
    /// Builder for the <see cref="ProcessorConfig"/>.
    /// </summary>
    public class ProcessorConfigBuilder
    {
        public ISource? Source { get; set; }
        public ISink? Sink { get; set; }

        public ProcessorConfig Build()
        {
            if (Source == null)
            {
                throw new InvalidOperationException(
                    "Source is null - a source must be provided before building.");
            }

            if (Sink == null)
            {
                throw new InvalidOperationException(
                    "Source is null - a source must be provided before building.");
            }

            return new ProcessorConfig(Source, Sink);
        }
    }
}
