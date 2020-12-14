using DatabaseModule;
using Processor;
using System;
using System.Linq;
using Xunit;

namespace XUnitTests
{
    [Collection("Sequential")]
    public class CreateFlashcardTests
    {
        [Fact]
        public void CreateFlashcardTestA()
        {
            ResetTestDatabasev2.Reset();

            ICreateFlashcard _processor = new CreateFlashcard(new CheckIfFlashcardIdIsUnique(), new CheckIfFlashcardIsUnique(), new InsertNewFlashcard(), new ValidateFlashcard());

            Assert.True(_processor.Create("XYZ", "XYZ", Guid.Parse("f34b0017-65e3-4f37-8d1b-4ab096f64046")));
            Assert.Empty(_processor.GetUserMessages());

            using (var db = new FlashcardsDbContext())
            {
                Assert.NotNull(db.FlashcardsDbModels.FirstOrDefault(e => e.NativeLanguage == "XYZ" && e.ForeignLanguage == "XYZ" && e.GroupDbModelId == Guid.Parse("f34b0017-65e3-4f37-8d1b-4ab096f64046")));
            }
        }

        [Fact]
        public void CreateFlashcardTestB()
        {
            ResetTestDatabasev2.Reset();

            ICreateFlashcard _processor = new CreateFlashcard(new CheckIfFlashcardIdIsUnique(), new CheckIfFlashcardIsUnique(), new InsertNewFlashcard(), new ValidateFlashcard());

            Assert.False(_processor.Create("Flashcard 1 Native", "Flashcard 1 Foreign", Guid.Parse("f34b0017-65e3-4f37-8d1b-4ab096f64046")));
            Assert.NotEmpty(_processor.GetUserMessages());
            Assert.Contains("Flashcard already exists.", _processor.GetUserMessages());
        }

        [Fact]
        public void CreateFlashcardTestC()
        {
            ResetTestDatabasev2.Reset();

            ICreateFlashcard _processor = new CreateFlashcard(new CheckIfFlashcardIdIsUnique(), new CheckIfFlashcardIsUnique(), new InsertNewFlashcard(), new ValidateFlashcard());

            Assert.True(_processor.Create("Flashcard 1 Native", "Flashcard 1 Foreign", Guid.Parse("1d917073-68ea-4e11-b4ae-816f30e33e72")));
            Assert.Empty(_processor.GetUserMessages());

            using (var db = new FlashcardsDbContext())
            {
                Assert.NotNull(db.FlashcardsDbModels.FirstOrDefault(e => e.NativeLanguage == "Flashcard 1 Native" && e.ForeignLanguage == "Flashcard 1 Foreign" && e.GroupDbModelId == Guid.Parse("1d917073-68ea-4e11-b4ae-816f30e33e72")));
            }
        }
    }
}
