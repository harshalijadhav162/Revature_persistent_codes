using Microsoft.Extensions.DependencyInjection;
using System;

namespace ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var services = new ServiceCollection();

            // Register dependencies
            services.AddScoped<IMessageReader, TwitterMessageReader>();
            services.AddScoped<IMessageWriter, InstagramMessageWriter>(); // Try changing to PdfMessageWriter
            services.AddScoped<IMyLogger, ConsoleLogger>();
            services.AddScoped<App>();

            var serviceProvider = services.BuildServiceProvider();

            var app = serviceProvider.GetRequiredService<App>();

            app.Run();
        }
    }

    public class App
    {
        IMessageReader _messageReader;
        IMessageWriter _messageWriter;

        public App(IMessageReader reader, IMessageWriter writer)
        {
            _messageReader = reader;
            _messageWriter = writer;
        }

        public void Run()
        {
            _messageWriter.WriteMessage(_messageReader.ReadMessage());
        }
    }

    public interface IMessageReader
    {
        string ReadMessage();
    }

    public class TwitterMessageReader : IMessageReader
    {
        public string ReadMessage() => "Hello, From Twitter!";
    }

    public interface IMessageWriter
    {
        void WriteMessage(string message);
    }

    public interface IMyLogger
    {
        void Log();
    }

    public class ConsoleLogger : IMyLogger
    {
        public void Log()
        {
            Console.WriteLine("Entering Console");
        }
    }

    public class InstagramMessageWriter : IMessageWriter
    {
        IMyLogger _logger;

        public InstagramMessageWriter(IMyLogger logger)
        {
            _logger = logger;
        }

        public void WriteMessage(string message)
        {
            _logger.Log();
            Console.WriteLine($"{message} posted to Instagram");
        }
    }

    public class PdfMessageWriter : IMessageWriter
    {
        public void WriteMessage(string message)
        {
            Console.WriteLine($"PDF: {message}");
        }
    }
}
