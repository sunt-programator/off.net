using Newtonsoft.Json.Linq;
using System;
using Off.Net.Pdf.Core.Primitives;
using Xunit;

namespace Off.Net.Pdf.Core.Tests.Primitives;

public class PdfBooleanTests
{
    [Fact(DisplayName = "Ensure that the parameterless constructor will set false to the Value property.")]
    public void PdfBoolean_ParameterlessConstructor_ShouldSetFalseToValueProperty()
    {
        // Arrange
        PdfBoolean pdfBoolean1 = new PdfBoolean();

        // Act

        // Assert
        Assert.False(pdfBoolean1.Value);
    }

    [Theory(DisplayName = "Create a instance using parametrized constructor and check the Value property")]
    [InlineData(true)]
    [InlineData(false)]
    public void PdfBoolean_ParameterizedContructor_CheckValue(bool value)
    {
        // Arrange
        PdfBoolean pdfBoolean = value; // Use an implicit conversion from bool to PdfBoolean

        // Act
        bool expectedValue = pdfBoolean.Value;

        // Assert
        Assert.Equal(expectedValue, pdfBoolean.Value);
    }

    [Theory(DisplayName = "Check the length of the PDF boolean primitive")]
    [InlineData(true, 4)]
    [InlineData(false, 5)]
    public void PdfBoolean_Length_CheckValue(bool value, int expectedLength)
    {
        // Arrange
        PdfBoolean pdfBoolean = value; // Use an implicit conversion from bool to PdfBoolean

        // Act
        int actualLength = pdfBoolean.Length;

        // Assert
        Assert.Equal(expectedLength, actualLength);
    }

    [Theory(DisplayName = "Check equality comparison operator")]
    [InlineData(false, false, true)]
    [InlineData(false, true, false)]
    [InlineData(true, false, false)]
    [InlineData(true, true, true)]
    public void PdfBoolean_Equality_CheckEqual(bool value1, bool value2, bool expectedResult)
    {
        // Arrange
        PdfBoolean pdfBoolean1 = value1; // Use an implicit conversion from bool to PdfBoolean
        PdfBoolean pdfBoolean2 = value2; // Use an implicit conversion from bool to PdfBoolean

        // Act
        bool actualResult = pdfBoolean1 == pdfBoolean2;

        // Assert
        Assert.Equal(expectedResult, actualResult);
    }

    [Theory(DisplayName = "Check inequality comparison operator")]
    [InlineData(false, false, false)]
    [InlineData(false, true, true)]
    [InlineData(true, false, true)]
    [InlineData(true, true, false)]
    public void PdfBoolean_Equality_CheckInequal(bool value1, bool value2, bool expectedResult)
    {
        // Arrange
        PdfBoolean pdfBoolean1 = value1; // Use an implicit conversion from bool to PdfBoolean
        PdfBoolean pdfBoolean2 = value2; // Use an implicit conversion from bool to PdfBoolean

        // Act
        bool actualResult = pdfBoolean1 != pdfBoolean2;

        // Assert
        Assert.Equal(expectedResult, actualResult);
    }

    [Fact(DisplayName = "Check Equals method if the argument is null")]
    public void PdfBoolean_Equals_NullArgument_ShouldReturnFalse()
    {
        // Arrange
        PdfBoolean pdfBoolean1 = true; // Use an implicit conversion from bool to PdfBoolean

        // Act
        bool actualResult = pdfBoolean1.Equals(null);

        // Assert
        Assert.False(actualResult);
    }

    [Theory(DisplayName = "Check Equals method with object type as an argument")]
    [InlineData(false, false, true)]
    [InlineData(false, true, false)]
    [InlineData(true, false, false)]
    [InlineData(true, true, true)]
    public void PdfBoolean_Equality_CheckEquals(bool value1, bool value2, bool expectedResult)
    {
        // Arrange
        PdfBoolean pdfBoolean1 = value1; // Use an implicit conversion from bool to PdfBoolean
        PdfBoolean pdfBoolean2 = value2; // Use an implicit conversion from bool to PdfBoolean

        // Act
        bool actualResult = pdfBoolean1.Equals((object)pdfBoolean2);

        // Assert
        Assert.Equal(expectedResult, actualResult);
    }

    [Theory(DisplayName = "Check if Bytes property returns valid data")]
    [InlineData(true, new byte[] { 0x74, 0x72, 0x75, 0x65 })]
    [InlineData(false, new byte[] { 0x66, 0x61, 0x6C, 0x73, 0x65 })]
    public void PdfBoolean_Bytes_CheckValidity(bool value1, byte[] expectedBytes)
    {
        // Arrange
        PdfBoolean pdfBoolean1 = value1; // Use an implicit conversion from bool to PdfBoolean

        // Act
        byte[] actualBytes = pdfBoolean1.Bytes;

        // Assert
        Assert.Equal(expectedBytes, actualBytes);
    }

    [Theory(DisplayName = "Check if GetHashCode method returns valid value")]
    [InlineData(false)]
    [InlineData(true)]
    public void PdfBoolean_GetHashCode_CheckValidity(bool value1)
    {
        // Arrange
        PdfBoolean pdfBoolean1 = value1; // Use an implicit conversion from bool to PdfBoolean
        int expectedHashCode = HashCode.Combine(nameof(PdfBoolean).GetHashCode(), value1.GetHashCode());

        // Act
        int actualHashCode = pdfBoolean1.GetHashCode();

        // Assert
        Assert.Equal(expectedHashCode, actualHashCode);
    }

    [Theory(DisplayName = "Check if comparison operators works properly")]
    [InlineData(false, false, "==", true)]
    [InlineData(false, false, "!=", false)]
    [InlineData(false, false, "<", false)]
    [InlineData(false, false, "<=", true)]
    [InlineData(false, false, ">", false)]
    [InlineData(false, false, ">=", true)]
    [InlineData(false, true, "==", false)]
    [InlineData(false, true, "!=", true)]
    [InlineData(false, true, "<", true)]
    [InlineData(false, true, "<=", true)]
    [InlineData(false, true, ">", false)]
    [InlineData(false, true, ">=", false)]
    [InlineData(true, false, "==", false)]
    [InlineData(true, false, "!=", true)]
    [InlineData(true, false, "<", false)]
    [InlineData(true, false, "<=", false)]
    [InlineData(true, false, ">", true)]
    [InlineData(true, false, ">=", true)]
    [InlineData(true, true, "==", true)]
    [InlineData(true, true, "!=", false)]
    [InlineData(true, true, "<", false)]
    [InlineData(true, true, "<=", true)]
    [InlineData(true, true, ">", false)]
    [InlineData(true, true, ">=", true)]
    public void PdfBoolean_Operators_CheckValidity(bool value1, bool value2, string op, bool expectedResult)
    {
        // Arrange
        PdfBoolean pdfBoolean1 = value1; // Use an implicit conversion from bool to PdfBoolean
        PdfBoolean pdfBoolean2 = value2; // Use an implicit conversion from bool to PdfBoolean

        // Act
        bool actualResult = op switch
        {
            "==" => pdfBoolean1 == pdfBoolean2,
            "!=" => pdfBoolean1 != pdfBoolean2,
            "<" => pdfBoolean1 < pdfBoolean2,
            "<=" => pdfBoolean1 <= pdfBoolean2,
            ">" => pdfBoolean1 > pdfBoolean2,
            ">=" => pdfBoolean1 >= pdfBoolean2,
            _ => throw new ArgumentException("Invalid operation", nameof(op)),
        };

        // Assert
        Assert.Equal(expectedResult, actualResult);
    }

    [Theory(DisplayName = "Check if implicit operator works")]
    [InlineData(false)]
    [InlineData(true)]
    public void PdfBoolean_CheckImplicitOperator(bool value1)
    {
        // Arrange
        var pdfBoolean1 = new PdfBoolean(value1);

        // Act
        bool actualValue = pdfBoolean1; // Use an implicit conversion from PdfBoolean to bool
        bool expectedValue = pdfBoolean1.Value;

        // Assert
        Assert.Equal(expectedValue, actualValue);
    }

    [Theory(DisplayName = "Check CompareTo method")]
    [InlineData(false, false, 0)]
    [InlineData(false, true, -1)]
    [InlineData(true, false, 1)]
    [InlineData(true, true, 0)]
    public void PdfBoolean_CompareTo_CheckValidity(bool value1, bool value2, int expectedValue)
    {
        // Arrange
        var pdfBoolean1 = new PdfBoolean(value1);
        object pdfBoolean2 = new PdfBoolean(value2);

        // Act
        int actualValue = pdfBoolean1.CompareTo(pdfBoolean2);

        // Assert
        Assert.Equal(expectedValue, actualValue);
    }

    [Fact(DisplayName = "Check CompareTo method should throw an exception")]
    public void PdfBoolean_CompareTo_ThrowsException()
    {
        // Arrange
        var pdfBoolean1 = new PdfBoolean();
        object pdfBoolean2 = 5;

        // Act
        Action actualValueDelegate = () => pdfBoolean1.CompareTo(pdfBoolean2);

        // Assert
        Assert.Throws<ArgumentException>(actualValueDelegate);
    }
}
