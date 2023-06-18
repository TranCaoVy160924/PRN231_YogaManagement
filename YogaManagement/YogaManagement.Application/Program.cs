using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.OData;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text.Json.Serialization;
using YogaManagement.Application.MapperConfig;
using YogaManagement.Application.Utilities;
using YogaManagement.Business.Repositories;
using YogaManagement.Contracts.Authority;
using YogaManagement.Contracts.Category;
using YogaManagement.Contracts.Course;
using YogaManagement.Contracts.Enrollment;
using YogaManagement.Contracts.MemberLevel;
using YogaManagement.Contracts.TeacherEnrollment;
using YogaManagement.Contracts.YogaClass;
using YogaManagement.Database.EF;
using YogaManagement.Domain.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddScoped<YogaManagementDbContext>();
builder.Services.AddIdentity<AppUser, AppRole>()
    .AddEntityFrameworkStores<YogaManagementDbContext>()
    .AddDefaultTokenProviders();

// Repository
builder.Services.AddScoped<MemberRepository>();
builder.Services.AddScoped<TeacherProfileRepository>();
builder.Services.AddScoped<YogaClassRepository>();
builder.Services.AddScoped<CourseRepository>();
builder.Services.AddScoped<CategoryRepository>();
builder.Services.AddScoped<WalletRepository>();

// Utilities
builder.Services.AddSingleton<JwtHelper>();

builder.Services.AddAutoMapper(Assembly.GetAssembly(typeof(MapperProfile)));

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
}).AddOData(options => options.Select().Filter().Count()
    .OrderBy().Expand().SetMaxTop(100)
    .AddRouteComponents("odata", GetEdmModel()));

//password policy configuration
builder.Services.Configure<IdentityOptions>(options =>
{
    // Default Password settings.
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 0;
});

//JWT configuration 
string issuer = builder.Configuration.GetValue<string>("JwtSettings:validIssuer");
string signingKey = builder.Configuration.GetValue<string>("JwtSettings:Key");

builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})

.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidIssuer = issuer,
        ValidateAudience = true,
        ValidAudience = issuer,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ClockSkew = System.TimeSpan.Zero,
        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(signingKey))
    };
});

builder.Services.AddAuthorization();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Swagger asset managment solution", Version = "v1" });
    c.CustomSchemaIds(type => type.ToString());
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                  {
                    {
                      new OpenApiSecurityScheme
                      {
                        Reference = new OpenApiReference
                          {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                          },
                          Scheme = "oauth2",
                          Name = "Bearer",
                          In = ParameterLocation.Header,
                        },
                        new List<string>()
                      }
                    });
});

builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("corsapp");

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

static IEdmModel GetEdmModel()
{
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();

    #region Yogaclass
    var ygclasses = builder.EntitySet<YogaClassDTO>("YogaClasses").EntityType;
    #endregion

    #region AppUser
    var appUsers = builder.EntitySet<UserDTO>("Users").EntityType;
    #endregion

    #region Course
    var course = builder.EntitySet<CourseDTO>("Courses").EntityType;
    #endregion

    #region Category
    var category = builder.EntitySet<CategoryDTO>("Categories").EntityType;
    #endregion

    #region Enrollment
    var enrollment = builder.EntitySet<EnrollmentDTO>("Enrollments").EntityType;
    enrollment.HasKey(e => new { e.MemberId, e.YogaClassId });
    #endregion

    #region TeacherEnrollment
    var teacherEnrollment = builder.EntitySet<TeacherEnrollmentDTO>("TeacherEnrollment").EntityType;
    #endregion

    #region MemberLevelDiscount
    var memberLevelDiscount = builder.EntitySet<MemberLevelDiscountDTO>("MemberLevel").EntityType;
    #endregion

    return builder.GetEdmModel();
}