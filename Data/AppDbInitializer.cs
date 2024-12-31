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
                    //if (!context.Candidates.Any())
                    //{
                    //    context.Candidates.AddRange(new List<Candidate>()
                    //    {
                    //        new Candidate()
                    //        {
                    //            FirstName = "John",
                    //            LastName = "Michael",
                    //            BirthDate = new DateTime(1990, 01, 01),
                    //            Email = "JohnMichael@me.com",
                    //            PhotoIdNumber = "123456789"
                    //        },
                    //        new Candidate()
                    //        {
                    //            FirstName = "Jane",
                    //            LastName = "Doe",
                    //            BirthDate = new DateTime(1989, 02, 02),
                    //            Email = "JaneDoe@me.com",
                    //            PhotoIdNumber = "993456789"
                    //        },

                    //        new Candidate()
                    //        {
                    //            FirstName = "John",
                    //            LastName = "Smith",
                    //            BirthDate = new DateTime(1987, 03, 04),
                    //            Email = "JohnSmith@me.com",
                    //            PhotoIdNumber = "883456789"
                    //        },
                    //    });
                    //    context.SaveChanges();
                    //}

                    //Certificates
                    if (!context.CertificateTopics.Any())
                    {
                        context.CertificateTopics.AddRange(new List<CertificateTopic>()
                        {
                            new CertificateTopic()
                            {
                                TopicName = TopicName.CSharpBasics,
                                Description = "C# Basics loremNo, Lorem Ipsum text is meant for placeholder purposes only. It should be replaced with actual content before the production release of your application or document.",
                                Price = 99.99
                            },
                            new CertificateTopic()
                            {
                                TopicName = TopicName.CSharpAdvanced,
                                Description = "C# Advanced loremNo, Lorem Ipsum text is meant for placeholder purposes only. It should be replaced with actual content before the production release of your application or document.",
                                Price = 89.99
                            },
                            new CertificateTopic()
                            {
                                TopicName = TopicName.JavaScriptBasics,
                                Description = "JavaScript Basics loremNo, Lorem Ipsum text is meant for placeholder purposes only. It should be replaced with actual content before the production release of your application or document.",
                                Price = 79.99
                            },
                            new CertificateTopic()
                            {
                                TopicName = TopicName.JavaScriptAdvanced,
                                Description = "JavaScript Advanced loremNo, Lorem Ipsum text is meant for placeholder purposes only. It should be replaced with actual content before the production release of your application or document.",
                                Price = 79.99
                            },
                            new CertificateTopic()
                            {
                                TopicName = TopicName.JavaScriptExpert,
                                Description = "JavaScript Expert loremNo, Lorem Ipsum text is meant for placeholder purposes only. It should be replaced with actual content before the production release of your application or document.",
                                Price = 79.99
                            },
                        });
                        context.SaveChanges();
                    }

                    //CandidateCertificates
                    //if (!context.CandidateCertificates.Any())
                    //{
                    //    context.CandidateCertificates.AddRange(new List<CandidateCertificate>()
                    //    {
                    //        new CandidateCertificate()
                    //        {
                    //            CandidateId = 1,
                    //            CertificateTopicId = 1,
                    //            ExaminationDate = new DateTime(2024,12,12),
                    //            CandidateScore = 1,
                    //            MaximumScore = 4,
                    //            ResultLabel = false

                    //        },
                    //        new CandidateCertificate()
                    //        {
                    //            CandidateId = 1,
                    //            CertificateTopicId = 2,
                    //            ExaminationDate = new DateTime(2024,10,12),
                    //            CandidateScore = 3,
                    //            MaximumScore = 4,
                    //            ResultLabel = true
                    //        },
                    //        new CandidateCertificate()
                    //        {
                    //            CandidateId = 2,
                    //            CertificateTopicId = 3,
                    //            ExaminationDate = new DateTime(2025,01,12),
                    //        },
                    //    });
                    //    context.SaveChanges();
                    //}

                    //Questions
                    if (!context.Questions.Any())
                    {
                        context.Questions.AddRange(new List<Question>()
                        {
                            //C# Basics
                            new Question() { QuestionText = "What is C#?", CertificateTopicId = 1, ImageSource = "", BooleanA = true, AnswerA = "C# is a programming language", BooleanB = false, AnswerB = "C# is a framework", BooleanC = false, AnswerC = "C# is a library", BooleanD = false, AnswerD = "C# is a compiler" },
                            new Question() { QuestionText = "Which keyword is used to declare a variable in C#?", CertificateTopicId = 1, ImageSource = "", BooleanA = false, AnswerA = "let", BooleanB = true, AnswerB = "var", BooleanC = false, AnswerC = "define", BooleanD = false, AnswerD = "declare" },
                            new Question() { QuestionText = "What does the 'using' directive in C# do?", CertificateTopicId = 1, ImageSource = "", BooleanA = false, AnswerA = "Creates a new instance", BooleanB = false, AnswerB = "Defines a new class", BooleanC = true, AnswerC = "Includes namespaces", BooleanD = false, AnswerD = "Executes a method" },
                            new Question() { QuestionText = "Which data type is used to store a whole number in C#?", CertificateTopicId = 1, ImageSource = "", BooleanA = false, AnswerA = "string", BooleanB = false, AnswerB = "double", BooleanC = false, AnswerC = "bool", BooleanD = true, AnswerD = "int" },
                            new Question() { QuestionText = "Which symbol is used to comment a single line in C#?", CertificateTopicId = 1, ImageSource = "", BooleanA = false, AnswerA = "/* */", BooleanB = false, AnswerB = "#", BooleanC = true, AnswerC = "//", BooleanD = false, AnswerD = "<!-- -->" },
                            new Question() { QuestionText = "What is the default value of a bool variable in C#?", CertificateTopicId = 1, ImageSource = "", BooleanA = false, AnswerA = "null", BooleanB = true, AnswerB = "false", BooleanC = false, AnswerC = "true", BooleanD = false, AnswerD = "undefined" },
                            new Question() { QuestionText = "Which of the following is not a valid access modifier in C#?", CertificateTopicId = 1, ImageSource = "", BooleanA = true, AnswerA = "external", BooleanB = false, AnswerB = "public", BooleanC = false, AnswerC = "private", BooleanD = false, AnswerD = "protected" },
                            new Question() { QuestionText = "What does the 'static' keyword indicate in C#?", CertificateTopicId = 1, ImageSource = "", BooleanA = false, AnswerA = "Cannot be overridden", BooleanB = false, AnswerB = "Is private by default", BooleanC = true, AnswerC = "Belongs to the class, not instance", BooleanD = false, AnswerD = "Cannot be inherited" },
                            new Question() { QuestionText = "Which loop is guaranteed to execute at least once in C#?", CertificateTopicId = 1, ImageSource = "", BooleanA = false, AnswerA = "while", BooleanB = false, AnswerB = "for", BooleanC = false, AnswerC = "foreach", BooleanD = true, AnswerD = "do-while" },
                            new Question() { QuestionText = "What is the file extension for a C# file?", CertificateTopicId = 1, ImageSource = "", BooleanA = true, AnswerA = ".cs", BooleanB = false, AnswerB = ".cpp", BooleanC = false, AnswerC = ".java", BooleanD = false, AnswerD = ".py" },

                            //C# Advanced
                            new Question()
                                {
                                    QuestionText = "What is LINQ in C#?",
                                    CertificateTopicId = 2,
                                    ImageSource = "",
                                    BooleanA = true,
                                    AnswerA = "Language Integrated Query",
                                    BooleanB = false,
                                    AnswerB = "Logical Integrated Query",
                                    BooleanC = false,
                                    AnswerC = "Library Interface Query",
                                    BooleanD = false,
                                    AnswerD = "Linear Integrated Query"
                                },
                                new Question()
                                {
                                    QuestionText = "What is the purpose of the 'yield' keyword in C#?",
                                    CertificateTopicId = 2,
                                    ImageSource = "",
                                    BooleanA = false,
                                    AnswerA = "Handles exceptions",
                                    BooleanB = false,
                                    AnswerB = "Defines an asynchronous method",
                                    BooleanC = true,
                                    AnswerC = "Generates a value in an iterator",
                                    BooleanD = false,
                                    AnswerD = "Terminates a loop"
                                },
                                new Question()
                                {
                                    QuestionText = "What is an extension method in C#?",
                                    CertificateTopicId = 2,
                                    ImageSource = "",
                                    BooleanA = false,
                                    AnswerA = "A method in a derived class",
                                    BooleanB = true,
                                    AnswerB = "A static method for an existing type",
                                    BooleanC = false,
                                    AnswerC = "A method that extends collections",
                                    BooleanD = false,
                                    AnswerD = "A method with a yield keyword"
                                },
                                new Question()
                                {
                                    QuestionText = "What is a nullable type in C#?",
                                    CertificateTopicId = 2,
                                    ImageSource = "",
                                    BooleanA = false,
                                    AnswerA = "A type with no value",
                                    BooleanB = false,
                                    AnswerB = "A type that allows null values",
                                    BooleanC = true,
                                    AnswerC = "A reference type only",
                                    BooleanD = false,
                                    AnswerD = "A value type only"
                                },
                                new Question()
                                {
                                    QuestionText = "What is the purpose of the 'async' keyword in C#?",
                                    CertificateTopicId = 2,
                                    ImageSource = "",
                                    BooleanA = false,
                                    AnswerA = "To pause a method",
                                    BooleanB = false,
                                    AnswerB = "To run methods in a separate thread",
                                    BooleanC = true,
                                    AnswerC = "To mark a method as asynchronous",
                                    BooleanD = false,
                                    AnswerD = "To define a thread-safe operation"
                                },
                                new Question()
                                {
                                    QuestionText = "What is the default accessibility for a class member in C#?",
                                    CertificateTopicId = 2,
                                    ImageSource = "",
                                    BooleanA = false,
                                    AnswerA = "public",
                                    BooleanB = true,
                                    AnswerB = "private",
                                    BooleanC = false,
                                    AnswerC = "protected",
                                    BooleanD = false,
                                    AnswerD = "internal"
                                },
                                new Question()
                                {
                                    QuestionText = "What does 'sealed' mean when applied to a class in C#?",
                                    CertificateTopicId = 2,
                                    ImageSource = "",
                                    BooleanA = true,
                                    AnswerA = "The class cannot be inherited",
                                    BooleanB = false,
                                    AnswerB = "The class cannot be instantiated",
                                    BooleanC = false,
                                    AnswerC = "The class cannot have static members",
                                    BooleanD = false,
                                    AnswerD = "The class is immutable"
                                },
                                new Question()
                                {
                                    QuestionText = "What is the purpose of a partial class in C#?",
                                    CertificateTopicId = 2,
                                    ImageSource = "",
                                    BooleanA = false,
                                    AnswerA = "To support multiple inheritance",
                                    BooleanB = true,
                                    AnswerB = "To split class definition across files",
                                    BooleanC = false,
                                    AnswerC = "To define static methods",
                                    BooleanD = false,
                                    AnswerD = "To ensure thread safety"
                                },
                                new Question()
                                {
                                    QuestionText = "What does 'override' mean in C#?",
                                    CertificateTopicId = 2,
                                    ImageSource = "",
                                    BooleanA = false,
                                    AnswerA = "Defines a new method",
                                    BooleanB = true,
                                    AnswerB = "Replaces a virtual method in a derived class",
                                    BooleanC = false,
                                    AnswerC = "Creates a new implementation of an interface",
                                    BooleanD = false,
                                    AnswerD = "Marks a class as inheritable"
                                },
                                new Question()
                                {
                                    QuestionText = "What is boxing in C#?",
                                    CertificateTopicId = 2,
                                    ImageSource = "",
                                    BooleanA = false,
                                    AnswerA = "Converting a reference type to a value type",
                                    BooleanB = false,
                                    AnswerB = "Converting a value type to a reference type",
                                    BooleanC = false,
                                    AnswerC = "Casting an object to its base type",
                                    BooleanD = true,
                                    AnswerD = "Storing objects in an array"
                                },

                                //JavaScript Basics
                                new Question()
                                {
                                    QuestionText = "What is JavaScript?",
                                    CertificateTopicId = 3,
                                    ImageSource = "",
                                    BooleanA = true,
                                    AnswerA = "A scripting language for web",
                                    BooleanB = false,
                                    AnswerB = "A server-side language",
                                    BooleanC = false,
                                    AnswerC = "A markup language",
                                    BooleanD = false,
                                    AnswerD = "A database query language"
                                },
                                new Question()
                                {
                                    QuestionText = "Which symbol is used to declare a variable in modern JavaScript?",
                                    CertificateTopicId = 3,
                                    ImageSource = "",
                                    BooleanA = false,
                                    AnswerA = "define",
                                    BooleanB = true,
                                    AnswerB = "let",
                                    BooleanC = false,
                                    AnswerC = "const",
                                    BooleanD = false,
                                    AnswerD = "var"
                                },
                                new Question()
                                {
                                    QuestionText = "What is the output of 'typeof null' in JavaScript?",
                                    CertificateTopicId = 3,
                                    ImageSource = "",
                                    BooleanA = false,
                                    AnswerA = "null",
                                    BooleanB = false,
                                    AnswerB = "undefined",
                                    BooleanC = true,
                                    AnswerC = "object",
                                    BooleanD = false,
                                    AnswerD = "boolean"
                                },
                                new Question()
                                {
                                    QuestionText = "Which of the following is not a JavaScript data type?",
                                    CertificateTopicId = 3,
                                    ImageSource = "",
                                    BooleanA = false,
                                    AnswerA = "boolean",
                                    BooleanB = false,
                                    AnswerB = "undefined",
                                    BooleanC = false,
                                    AnswerC = "integer",
                                    BooleanD = true,
                                    AnswerD = "symbol"
                                },
                                new Question()
                                {
                                    QuestionText = "What is the correct syntax for creating a function in JavaScript?",
                                    CertificateTopicId = 3,
                                    ImageSource = "",
                                    BooleanA = false,
                                    AnswerA = "function myFunction[] {}",
                                    BooleanB = true,
                                    AnswerB = "function myFunction() {}",
                                    BooleanC = false,
                                    AnswerC = "def myFunction() {}",
                                    BooleanD = false,
                                    AnswerD = "myFunction function() {}"
                                },
                                new Question()
                                {
                                    QuestionText = "Which of the following is used to add an element to the end of an array in JavaScript?",
                                    CertificateTopicId = 3,
                                    ImageSource = "",
                                    BooleanA = true,
                                    AnswerA = "push()",
                                    BooleanB = false,
                                    AnswerB = "pop()",
                                    BooleanC = false,
                                    AnswerC = "shift()",
                                    BooleanD = false,
                                    AnswerD = "unshift()"
                                },
                                new Question()
                                {
                                    QuestionText = "What does '===' operator do in JavaScript?",
                                    CertificateTopicId = 3,
                                    ImageSource = "",
                                    BooleanA = false,
                                    AnswerA = "Compares only values",
                                    BooleanB = true,
                                    AnswerB = "Compares values and types",
                                    BooleanC = false,
                                    AnswerC = "Assigns values",
                                    BooleanD = false,
                                    AnswerD = "Checks if variables exist"
                                },
                                new Question()
                                {
                                    QuestionText = "What is the correct way to write an 'if' statement in JavaScript?",
                                    CertificateTopicId = 3,
                                    ImageSource = "",
                                    BooleanA = false,
                                    AnswerA = "if x > 5 then",
                                    BooleanB = false,
                                    AnswerB = "if (x > 5)",
                                    BooleanC = true,
                                    AnswerC = "if x > 5:",
                                    BooleanD = false,
                                    AnswerD = "if x > 5;"
                                },
                                new Question()
                                {
                                    QuestionText = "What is the default value of an uninitialized variable in JavaScript?",
                                    CertificateTopicId = 3,
                                    ImageSource = "",
                                    BooleanA = false,
                                    AnswerA = "null",
                                    BooleanB = true,
                                    AnswerB = "undefined",
                                    BooleanC = false,
                                    AnswerC = "0",
                                    BooleanD = false,
                                    AnswerD = "false"
                                },
                                new Question()
                                {
                                    QuestionText = "What is the purpose of the 'this' keyword in JavaScript?",
                                    CertificateTopicId = 3,
                                    ImageSource = "",
                                    BooleanA = false,
                                    AnswerA = "Refers to the global object",
                                    BooleanB = true,
                                    AnswerB = "Refers to the object it belongs to",
                                    BooleanC = false,
                                    AnswerC = "Refers to the function name",
                                    BooleanD = false,
                                    AnswerD = "Refers to the parent function"
                                },

                                //JavaScript Advanced
                                new Question()
                                {
                                    QuestionText = "What is the purpose of closures in JavaScript?",
                                    CertificateTopicId = 4,
                                    ImageSource = "",
                                    BooleanA = false,
                                    AnswerA = "To create new data types",
                                    BooleanB = true,
                                    AnswerB = "To preserve variable scope in nested functions",
                                    BooleanC = false,
                                    AnswerC = "To handle asynchronous code",
                                    BooleanD = false,
                                    AnswerD = "To define classes"
                                },
                                new Question()
                                {
                                    QuestionText = "Which method is used to bind a function to a specific object in JavaScript?",
                                    CertificateTopicId = 4,
                                    ImageSource = "",
                                    BooleanA = false,
                                    AnswerA = "attach()",
                                    BooleanB = false,
                                    AnswerB = "apply()",
                                    BooleanC = true,
                                    AnswerC = "bind()",
                                    BooleanD = false,
                                    AnswerD = "call()"
                                },
                                new Question()
                                {
                                    QuestionText = "What is the purpose of the 'Promise.all' method?",
                                    CertificateTopicId = 4,
                                    ImageSource = "",
                                    BooleanA = true,
                                    AnswerA = "To execute multiple promises in parallel and wait for all to resolve",
                                    BooleanB = false,
                                    AnswerB = "To execute promises sequentially",
                                    BooleanC = false,
                                    AnswerC = "To handle rejected promises only",
                                    BooleanD = false,
                                    AnswerD = "To create a chain of promises"
                                },
                                new Question()
                                {
                                    QuestionText = "What does the 'async' keyword do in JavaScript?",
                                    CertificateTopicId = 4,
                                    ImageSource = "",
                                    BooleanA = false,
                                    AnswerA = "Marks a function to run on a separate thread",
                                    BooleanB = false,
                                    AnswerB = "Pauses the execution of a function",
                                    BooleanC = true,
                                    AnswerC = "Marks a function to return a promise",
                                    BooleanD = false,
                                    AnswerD = "Handles errors in a function"
                                },
                                new Question()
                                {
                                    QuestionText = "What is the purpose of the 'debounce' technique in JavaScript?",
                                    CertificateTopicId = 4,
                                    ImageSource = "",
                                    BooleanA = false,
                                    AnswerA = "To prevent multiple promises from executing",
                                    BooleanB = true,
                                    AnswerB = "To limit the rate at which a function executes",
                                    BooleanC = false,
                                    AnswerC = "To ensure all functions execute in sequence",
                                    BooleanD = false,
                                    AnswerD = "To cache the results of a function"
                                },
                                new Question()
                                {
                                    QuestionText = "What does the 'call' method do in JavaScript?",
                                    CertificateTopicId = 4,
                                    ImageSource = "",
                                    BooleanA = false,
                                    AnswerA = "Returns a promise from a function",
                                    BooleanB = false,
                                    AnswerB = "Binds a function to an object permanently",
                                    BooleanC = true,
                                    AnswerC = "Invokes a function with a specified 'this' value and arguments",
                                    BooleanD = false,
                                    AnswerD = "Executes a function after a delay"
                                },
                                new Question()
                                {
                                    QuestionText = "What is the difference between '==' and '===' in JavaScript?",
                                    CertificateTopicId = 4,
                                    ImageSource = "",
                                    BooleanA = true,
                                    AnswerA = "== checks values only, === checks values and types",
                                    BooleanB = false,
                                    AnswerB = "== checks types only, === checks values only",
                                    BooleanC = false,
                                    AnswerC = "== compares references, === compares objects",
                                    BooleanD = false,
                                    AnswerD = "== is for arrays, === is for strings"
                                },
                                new Question()
                                {
                                    QuestionText = "What does the 'Object.freeze()' method do in JavaScript?",
                                    CertificateTopicId = 4,
                                    ImageSource = "",
                                    BooleanA = false,
                                    AnswerA = "Prevents an object from being iterated",
                                    BooleanB = false,
                                    AnswerB = "Allows only primitive types as keys",
                                    BooleanC = true,
                                    AnswerC = "Prevents modifications to an object's properties",
                                    BooleanD = false,
                                    AnswerD = "Converts an object to a frozen array"
                                },
                                new Question()
                                {
                                    QuestionText = "What is the purpose of the 'reduce()' method in JavaScript arrays?",
                                    CertificateTopicId = 4,
                                    ImageSource = "",
                                    BooleanA = false,
                                    AnswerA = "To filter an array based on a condition",
                                    BooleanB = false,
                                    AnswerB = "To iterate over an array",
                                    BooleanC = false,
                                    AnswerC = "To concatenate arrays",
                                    BooleanD = true,
                                    AnswerD = "To accumulate values into a single result"
                                },
                                new Question()
                                {
                                    QuestionText = "What is an Immediately Invoked Function Expression (IIFE)?",
                                    CertificateTopicId = 4,
                                    ImageSource = "",
                                    BooleanA = true,
                                    AnswerA = "A function that runs as soon as it is defined",
                                    BooleanB = false,
                                    AnswerB = "A function invoked by an event listener",
                                    BooleanC = false,
                                    AnswerC = "A function that returns a promise",
                                    BooleanD = false,
                                    AnswerD = "A function with a setTimeout call"
                                },

                                // C# Expert
                                new Question()
                                {
                                    QuestionText = "What is the purpose of the 'unsafe' keyword in C#?",
                                    CertificateTopicId = 5,
                                    ImageSource = "",
                                    BooleanA = false,
                                    AnswerA = "To disable runtime exceptions",
                                    BooleanB = false,
                                    AnswerB = "To allow manipulation of unmanaged pointers",
                                    BooleanC = true,
                                    AnswerC = "To define blocks of code that use pointers",
                                    BooleanD = false,
                                    AnswerD = "To enable multithreading"
                                },
                                new Question()
                                {
                                    QuestionText = "Which attribute is used to specify that a method supports asynchronous programming?",
                                    CertificateTopicId = 5,
                                    ImageSource = "",
                                    BooleanA = true,
                                    AnswerA = "[Async]",
                                    BooleanB = false,
                                    AnswerB = "[AsyncTask]",
                                    BooleanC = false,
                                    AnswerC = "[TaskMethod]",
                                    BooleanD = false,
                                    AnswerD = "[Awaitable]"
                                },
                                new Question()
                                {
                                    QuestionText = "What is the difference between 'ref' and 'out' parameters in C#?",
                                    CertificateTopicId = 5,
                                    ImageSource = "",
                                    BooleanA = false,
                                    AnswerA = "ref parameters must be initialized before being passed; out parameters do not need initialization",
                                    BooleanB = true,
                                    AnswerB = "out parameters must be assigned inside the method, while ref parameters retain their values",
                                    BooleanC = false,
                                    AnswerC = "ref parameters are passed by value, while out parameters are passed by reference",
                                    BooleanD = false,
                                    AnswerD = "Both are identical in functionality"
                                },
                                new Question()
                                {
                                    QuestionText = "What is the purpose of the 'yield' keyword in C#?",
                                    CertificateTopicId = 5,
                                    ImageSource = "",
                                    BooleanA = false,
                                    AnswerA = "To mark a method as asynchronous",
                                    BooleanB = true,
                                    AnswerB = "To produce an iterator block",
                                    BooleanC = false,
                                    AnswerC = "To create a new thread",
                                    BooleanD = false,
                                    AnswerD = "To return a value to the caller immediately"
                                },
                                new Question()
                                {
                                    QuestionText = "Which collection in C# is best suited for high-performance key-value lookups?",
                                    CertificateTopicId = 5,
                                    ImageSource = "",
                                    BooleanA = false,
                                    AnswerA = "List",
                                    BooleanB = false,
                                    AnswerB = "Array",
                                    BooleanC = true,
                                    AnswerC = "Dictionary",
                                    BooleanD = false,
                                    AnswerD = "Queue"
                                },
                                new Question()
                                {
                                    QuestionText = "What is the main difference between abstract classes and interfaces in C#?",
                                    CertificateTopicId = 5,
                                    ImageSource = "",
                                    BooleanA = false,
                                    AnswerA = "Abstract classes cannot have properties, interfaces can",
                                    BooleanB = true,
                                    AnswerB = "Abstract classes can have implemented methods, interfaces cannot (pre-C# 8.0)",
                                    BooleanC = false,
                                    AnswerC = "Interfaces support constructors, abstract classes do not",
                                    BooleanD = false,
                                    AnswerD = "Interfaces support fields, abstract classes do not"
                                },
                                new Question()
                                {
                                    QuestionText = "What is the purpose of the 'sealed' keyword in C#?",
                                    CertificateTopicId = 5,
                                    ImageSource = "",
                                    BooleanA = false,
                                    AnswerA = "To make a class immutable",
                                    BooleanB = false,
                                    AnswerB = "To prevent instantiation of a class",
                                    BooleanC = true,
                                    AnswerC = "To prevent a class from being inherited",
                                    BooleanD = false,
                                    AnswerD = "To create a singleton class"
                                },
                                new Question()
                                {
                                    QuestionText = "What is the difference between 'finalize' and 'dispose' in C#?",
                                    CertificateTopicId = 5,
                                    ImageSource = "",
                                    BooleanA = true,
                                    AnswerA = "'Dispose' is explicitly called to release unmanaged resources, while 'Finalize' is invoked by the garbage collector",
                                    BooleanB = false,
                                    AnswerB = "'Dispose' is for managed resources, 'Finalize' is for unmanaged resources",
                                    BooleanC = false,
                                    AnswerC = "Both are used for memory allocation",
                                    BooleanD = false,
                                    AnswerD = "Both are automatically invoked"
                                },
                                new Question()
                                {
                                    QuestionText = "Which feature allows you to run multiple tasks concurrently in C#?",
                                    CertificateTopicId = 5,
                                    ImageSource = "",
                                    BooleanA = false,
                                    AnswerA = "Yield",
                                    BooleanB = false,
                                    AnswerB = "Polymorphism",
                                    BooleanC = true,
                                    AnswerC = "Asynchronous programming with async/await",
                                    BooleanD = false,
                                    AnswerD = "Dependency Injection"
                                },
                                new Question()
                                {
                                    QuestionText = "What does the 'lock' statement in C# do?",
                                    CertificateTopicId = 5,
                                    ImageSource = "",
                                    BooleanA = true,
                                    AnswerA = "Ensures that a block of code runs by only one thread at a time",
                                    BooleanB = false,
                                    AnswerB = "Locks the thread to prevent termination",
                                    BooleanC = false,
                                    AnswerC = "Stops the execution of a program",
                                    BooleanD = false,
                                    AnswerD = "Secures variables for garbage collection"
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