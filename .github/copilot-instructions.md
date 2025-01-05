Always use VisualStudio Test Tools when generating unit tests

All test names should be in the format [MethodBeingTested]_Should_[Assertion]_When_[OptionalCondition]

There should only be one assert per test

The When clause should only be included if there is an optional condition

Tests should be written in the AAA (Arrange, Act, Assert) pattern

Do not test constructors or properties

The test class should have a region named Tests in the class body. Do not wrap the class in the Tests region.  Inside that region should be a region for each method being tested.  Inside that region should be the tests for that method.