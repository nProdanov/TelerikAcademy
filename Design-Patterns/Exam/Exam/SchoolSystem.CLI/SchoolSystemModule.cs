using Ninject;
using Ninject.Extensions.Conventions;
using Ninject.Extensions.Factory;
using Ninject.Extensions.Interception.Infrastructure.Language;
using Ninject.Modules;
using SchoolSystem.Cli.Configuration;
using SchoolSystem.Cli.Interceptors;
using SchoolSystem.Framework.Core.Commands;
using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Core.Contracts;
using SchoolSystem.Framework.Core.Handlers;
using SchoolSystem.Framework.Core.Providers;
using SchoolSystem.Framework.Models.Factories;
using System.IO;
using System.Reflection;

namespace SchoolSystem.Cli
{
    public class SchoolSystemModule : NinjectModule
    {
        private const string ConsoleWriterProviderName = "ConsoleWriterProvider";
        private const string ConsoleReaderProviderName = "ConsoleReaderProvider";
        private const string CommandParserProviderName = "CommandParserProvider";

        private const string CreateStudentCommandName = "CreateStudentCommand";
        private const string CreateTeacherCommandName = "CreateTeacherCommand";
        private const string RemoveStudentCommandName = "RemoveStudentCommand";
        private const string RemoveTeacherCommandName = "RemoveTeacherCommand";
        private const string StudentListMarksCommandName = "StudentListMarksCommand";
        private const string TeacherAddMarkCommandName = "TeacherAddMarkCommand";

        private const string CreateStudentCommandHandlerName = "CreateStudentCommandHandler";
        private const string CreateTeacherCommandHandlerName = "CreateTeacherCommandHandler";
        private const string RemoveStudentCommandHandlerName = "RemoveStudentCommandHandler";
        private const string RemoveTeacherCommandHandlerName = "RemoveTeacherCommandHandler";
        private const string StudentListMarksCommandHandlerName = "StudentListMarksCommandHandler";
        private const string TeacherAddMarkCommandHandlerName = "TeacherAddMarkCommandHandler";

        public override void Load()
        {
            Kernel.Bind(x =>
            {
                x.FromAssembliesInPath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))
                .SelectAllClasses()
                .BindDefaultInterface();
            });

            Bind<IWriter>().To<ConsoleWriterProvider>().InSingletonScope().Named(ConsoleWriterProviderName);
            Bind<IReader>().To<ConsoleReaderProvider>().InSingletonScope().Named(ConsoleReaderProviderName);
            Bind<IParser>().To<CommandParserProvider>().InSingletonScope().Named(CommandParserProviderName);

            Bind<ICommand>().To<CreateStudentCommand>().InSingletonScope().Named(CreateStudentCommandName);
            Bind<ICommand>().To<CreateTeacherCommand>().InSingletonScope().Named(CreateTeacherCommandName);
            Bind<ICommand>().To<RemoveStudentCommand>().InSingletonScope().Named(RemoveStudentCommandName);
            Bind<ICommand>().To<RemoveTeacherCommand>().InSingletonScope().Named(RemoveTeacherCommandName);
            Bind<ICommand>().To<StudentListMarksCommand>().InSingletonScope().Named(StudentListMarksCommandName);
            Bind<ICommand>().To<TeacherAddMarkCommand>().InSingletonScope().Named(TeacherAddMarkCommandName);

            Bind<IHandler>().To<CreateStudentCommandHandler>().Named(CreateStudentCommandHandlerName);
            Bind<IHandler>().To<CreateTeacherCommandHandler>().Named(CreateTeacherCommandHandlerName);
            Bind<IHandler>().To<RemoveStudentCommandHandler>().Named(RemoveStudentCommandHandlerName);
            Bind<IHandler>().To<RemoveTeacherCommandHandler>().Named(RemoveTeacherCommandHandlerName);
            Bind<IHandler>().To<StudentListMarksCommandHandler>().Named(StudentListMarksCommandHandlerName);
            Bind<IHandler>().To<TeacherAddMarkCommandHandler>().Named(TeacherAddMarkCommandHandlerName);

            Bind<IHandler>()
                .ToMethod(context =>
                {
                    IHandler createStudentCommandHandler = context.Kernel.Get <IHandler>(CreateStudentCommandHandlerName);
                    IHandler createTeacherCommandHandler = context.Kernel.Get<IHandler>(CreateTeacherCommandHandlerName);
                    IHandler removeStudentCommandHandler = context.Kernel.Get<IHandler>(RemoveStudentCommandHandlerName);
                    IHandler removeTeacherCommandHandler = context.Kernel.Get<IHandler>(RemoveTeacherCommandHandlerName);
                    IHandler studentListMarksCommandHandler = context.Kernel.Get<IHandler>(StudentListMarksCommandHandlerName);
                    IHandler teacherAddMarkCommandHandler = context.Kernel.Get<IHandler>(TeacherAddMarkCommandHandlerName);

                    createStudentCommandHandler.SetSuccessor(createTeacherCommandHandler);
                    createTeacherCommandHandler.SetSuccessor(removeStudentCommandHandler);
                    removeStudentCommandHandler.SetSuccessor(removeTeacherCommandHandler);
                    removeTeacherCommandHandler.SetSuccessor(studentListMarksCommandHandler);
                    studentListMarksCommandHandler.SetSuccessor(teacherAddMarkCommandHandler);
                    
                    return createStudentCommandHandler;
                })
                .WhenInjectedInto<CommandParserProvider>();

            Bind<ITeachersFactory>().ToFactory().InSingletonScope();
            var studentsFactoryBinding = Bind<IStudentsFactory>().ToFactory().InSingletonScope();
            var commandsFactoryBinding = Bind<ICommandsFactory>().ToFactory().InSingletonScope();
            var marksFactoryBinding = Bind<IMarksFactory>().ToFactory().InSingletonScope();

            IConfigurationProvider configurationProvider = Kernel.Get<IConfigurationProvider>();
            if (configurationProvider.IsTestEnvironment)
            {
                studentsFactoryBinding.Intercept().With<TestMeasurementInterceptor>();
                commandsFactoryBinding.Intercept().With<TestMeasurementInterceptor>();
                marksFactoryBinding.Intercept().With<TestMeasurementInterceptor>();
            }
        }
    }
}