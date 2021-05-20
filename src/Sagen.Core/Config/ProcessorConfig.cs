namespace Sagen.Core.Config
{
    /// <summary>
    /// Configuration for the <see cref="Processor"/>.
    /// </summary>
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
