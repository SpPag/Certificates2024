using Certificates2024.Data.Enums;
using Certificates2024.Data.Static;
using Certificates2024.Models;
using Microsoft.AspNetCore.Identity;

namespace Certificates2024.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                {
                    var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                    context.Database.EnsureCreated();

                    //Candidates
                    if (!context.Candidates.Any())
                    {
                        context.Candidates.AddRange(new List<Candidate>()
                        {
                            new Candidate()
                            {
                                FirstName = "John",
                                LastName = "Michael",
                                BirthDate = new DateTime(1990, 01, 01),
                                Email = "JohnMichael@me.com",
                                PhotoIdNumber = "123456789"
                            },
                            new Candidate()
                            {
                                FirstName = "Jane",
                                LastName = "Doe",
                                BirthDate = new DateTime(1989, 02, 02),
                                Email = "JaneDoe@me.com",
                                PhotoIdNumber = "993456789"
                            },

                            new Candidate()
                            {
                                FirstName = "John",
                                LastName = "Smith",
                                BirthDate = new DateTime(1987, 03, 04),
                                Email = "JohnSmith@me.com",
                                PhotoIdNumber = "883456789"
                            },
                        });
                        context.SaveChanges();
                    }

                    //Certificates
                    if (!context.CertificateTopics.Any())
                    {
                        context.CertificateTopics.AddRange(new List<CertificateTopic>()
                        {
                            new CertificateTopic()
                            {
                                TopicName = TopicName.CSharpBasics
                            },
                            new CertificateTopic()
                            {
                                TopicName = TopicName.CSharpAdvanced
                            },
                            new CertificateTopic()
                            {
                                TopicName = TopicName.JavaScriptBasics
                            },
                            new CertificateTopic()
                            {
                                TopicName = TopicName.JavaScriptAdvanced
                            },
                            new CertificateTopic()
                            {
                                TopicName = TopicName.JavaScriptExpert
                            },
                        });
                        context.SaveChanges();
                    }

                    //CandidateCertificates
                    if (!context.CandidateCertificates.Any())
                    {
                        context.CandidateCertificates.AddRange(new List<CandidateCertificate>()
                        {
                            new CandidateCertificate()
                            {
                                CandidateId = 1,
                                CertificateTopicId = 1,
                                ExaminationDate = new DateTime(2024,12,12),
                                CandidateScore = 1,
                                MaximumScore = 4,
                                ResultLabel = false

                            },
                            new CandidateCertificate()
                            {
                                CandidateId = 1,
                                CertificateTopicId = 2,
                                ExaminationDate = new DateTime(2024,10,12),
                                CandidateScore = 3,
                                MaximumScore = 4,
                                ResultLabel = true
                            },
                            new CandidateCertificate()
                            {
                                CandidateId = 2,
                                CertificateTopicId = 3,
                                ExaminationDate = new DateTime(2025,01,12),
                            },
                        });
                        context.SaveChanges();
                    }

                    //Questions
                    if (!context.Questions.Any())
                    {
                         context.Questions.AddRange(new List<Question>()
                        {
                            new Question()
                            {
                                QuestionText = "What is C#?",
                                CertificateTopicId = 1,
                                ImageSource = "",
                                BooleanA = true,
                                AnswerA = "C# is a programming language",
                                BooleanB = false,
                                AnswerB = "C# is a framework",
                                BooleanC = false,
                                AnswerC = "C# is a library",
                                BooleanD = false,
                                AnswerD = "C# is a compiler"
                            },
                            new Question()
                            {
                                CertificateTopicId = 1,
                                QuestionText = "What is C++?",
                                ImageSource = "",
                                BooleanA = false,
                                AnswerA = "C++ is a framework",
                                BooleanB = true,
                                AnswerB = "C++ is a programming language",
                                BooleanC = false,
                                AnswerC = "C++ is a library",
                                BooleanD = false,
                                AnswerD = "C++ is a compiler"
                            },
                            new Question()
                            {
                                CertificateTopicId = 1,
                                QuestionText = "What is Java?",
                                ImageSource = "",
                                BooleanA = false,
                                AnswerA = "Java is a framework",
                                BooleanB = false,
                                AnswerB = "Java is a programming language",
                                BooleanC = true,
                                AnswerC = "Java is a library",
                                BooleanD = false,
                                AnswerD = "Java is a compiler"
                            },
                            new Question()
                            {
                                CertificateTopicId = 1,
                                QuestionText = "What is Python?",
                                ImageSource = "",
                                BooleanA = false,
                                AnswerA = "Python is a framework",
                                BooleanB = false,
                                AnswerB = "Python is a programming language",
                                BooleanC = false,
                                AnswerC = "Python is a library",
                                BooleanD = true,
                                AnswerD = "Python is a compiler"
                            },
                            new Question()
                            {
                                QuestionText = "What is JavaScript?",
                                CertificateTopicId = 3,
                                ImageSource = "",
                                BooleanA = false,
                                AnswerA = "JavaScript is a framework",
                                BooleanB = true,
                                AnswerB = "JavaScript is a programming language",
                                BooleanC = false,
                                AnswerC = "JavaScript is a library",
                                BooleanD = false,
                                AnswerD = "JavaScript is a compiler"
                            },
                            new Question()
                            {
                                QuestionText = "What is Java?",
                                CertificateTopicId = 2,
                                ImageSource = "",
                                BooleanA = false,
                                AnswerA = "Java is a framework",
                                BooleanB = false,
                                AnswerB = "Java is a programming language",
                                BooleanC = true,
                                AnswerC = "Java is a library",
                                BooleanD = false,
                                AnswerD = "Java is a compiler"
                            },
                            new Question()
                            {
                                QuestionText = "What is Python?",
                                CertificateTopicId = 4,
                                ImageSource = "",
                                BooleanA = false,
                                AnswerA = "Python is a framework",
                                BooleanB = false,
                                AnswerB = "Python is a programming language",
                                BooleanC = false,
                                AnswerC = "Python is a library",
                                BooleanD = true,
                                AnswerD = "Python is a compiler"
                            },
                        });
                        context.SaveChanges();
                    }
                }
            }
        }
        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {

                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                string adminUserEmail = "admin@certificates.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        FullName = "Unimaginative Admin",
                        UserName = "admin",
                        Email = adminUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdminUser, "Admin12#$");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }


                string appUserEmail = "pleb@certificates.com";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new ApplicationUser()
                    {
                        FullName = "Pleb User",
                        UserName = "pleb",
                        Email = appUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAppUser, "Pleb12#$");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }
    }
}
