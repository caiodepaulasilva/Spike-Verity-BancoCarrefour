using Domain;
using API_Releases.Validators;
using FluentValidation.TestHelper;

namespace Tests
{
    [TestFixture]
    public class ReleaseValidatorTest
    {
        private ReleaseValidator validator;

        [SetUp]
        public void Setup()
        {
            validator = new ReleaseValidator();
        }

        [Test]
        public void Should_have_error_when_Description_is_null()
        {
            var model = new Release { Description = null };
            var result = validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(release => release.Description);
        }

        [Test]
        public void Should_not_have_error_when_name_is_specified()
        {
            var model = new Release { Description = "Teste" };
            var result = validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(release => release.Description);
        }

        [Test]
        public void Should_not_have_error_when_Amount_is_negative()
        {
            var model = new Release { Amount = -20M };
            var result = validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(release => release.Amount);
        }

        [Test]
        public void Should_have_error_when_Amount_is_specified()
        {
            var model = new Release { Amount = 20M };
            var result = validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(release => release.Amount);
        }

        [Test]
        public void Should_have_error_when_TransactionType_is_specified()
        {
            var model = new Release { TransactionType = Domain.Enum.TransactionType.Debit };
            var result = validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(release => release.TransactionType);
        }
    }
}