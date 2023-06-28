//setup our DI
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using YogaManagement.Business.Repositories;
using YogaManagement.Database.EF;
using YogaManagement.DateChecker;

var serviceProvider = new ServiceCollection()
    .AddScoped<MemberRepository>()
    .AddScoped<TeacherProfileRepository>()
    .AddScoped<YogaClassRepository>()
    .AddScoped<CourseRepository>()
    .AddScoped<CategoryRepository>()
    .AddScoped<TeacherEnrollmentRepository>()
    .AddScoped<WalletRepository>()
    .AddScoped<MemberLevelDiscountRepository>()
    .AddScoped<MemberLevelConditonRepository>()
    .AddScoped<TimeSlotRepository>()
    .AddScoped<EnrollmentRepository>()
    .AddScoped<TeacherScheduleRepository>()
    .AddScoped<ScheduleRepository>()
    .AddScoped<TransactionRepository>();
serviceProvider.AddScoped<DateTimeChecker>();
serviceProvider.AddScoped<YogaManagementDbContext>();

var hostServices = serviceProvider.BuildServiceProvider();

var dateTimeChecker = hostServices.GetService<DateTimeChecker>();
await dateTimeChecker.UpdateOngoingCourseClass();
await dateTimeChecker.UpdateFinishCourseClassAsync();
Console.WriteLine("Finished! Press any key to close");

Console.ReadKey();
