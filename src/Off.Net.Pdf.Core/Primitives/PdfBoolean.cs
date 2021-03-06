namespace Off.Net.Pdf.Core.Primitives;

using System.Text;
using Off.Net.Pdf.Core.Interfaces;

/// <summary>
/// Represents a PDF Boolean object.
/// </summary>
/// <seealso cref="IPdfObject{bool}" />
public struct PdfBoolean : IPdfObject<bool>, IEquatable<PdfBoolean>, IComparable, IComparable<PdfBoolean>
{
    private const string FalseLiteral = "false";
    private const string TrueLiteral = "true";
    private static readonly byte[] FalseBytes = Encoding.ASCII.GetBytes(FalseLiteral);
    private static readonly byte[] TrueBytes = Encoding.ASCII.GetBytes(TrueLiteral);
    private static readonly int primitiveHashCodePrefix = nameof(PdfBoolean).GetHashCode();

    /// <summary>
    /// Initializes a new instance of the <see cref="PdfBoolean"/> struct.
    /// </summary>
    public PdfBoolean() : this(false)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="PdfBoolean"/> struct.
    /// </summary>
    /// <param name="value">The value of the Boolean object.</param>
    public PdfBoolean(bool value)
    {
        Value = value;
    }

    /// <inheritdoc/>
    public int Length => ToString().Length;

    /// <inheritdoc/>
    public bool Value { get; }

    /// <inheritdoc/>
    public byte[] Bytes => Value ? TrueBytes : FalseBytes;

    /// <inheritdoc/>
    public override int GetHashCode() => HashCode.Combine(primitiveHashCodePrefix, Value.GetHashCode());

    /// <inheritdoc/>
    public override string ToString() => Value ? TrueLiteral : FalseLiteral;

    #region Operators
    /// <summary>
    /// Implements the operator ==.
    /// </summary>
    /// <param name="leftOperator">The left operator.</param>
    /// <param name="rightOperator">The right operator.</param>
    /// <returns>The result of the operator.</returns>
    public static bool operator ==(PdfBoolean leftOperator, PdfBoolean rightOperator) => leftOperator.CompareTo(rightOperator) == 0;

    /// <summary>
    /// Implements the operator !=.
    /// </summary>
    /// <param name="leftOperator">The left operator.</param>
    /// <param name="rightOperator">The right operator.</param>
    /// <returns>The result of the operator.</returns>
    public static bool operator !=(PdfBoolean leftOperator, PdfBoolean rightOperator) => leftOperator.CompareTo(rightOperator) != 0;

    /// <summary>
    /// Implements the operator ==.
    /// </summary>
    /// <param name="leftOperator">The left operator.</param>
    /// <param name="rightOperator">The right operator.</param>
    /// <returns>The result of the operator.</returns>
    public static bool operator <(PdfBoolean leftOperator, PdfBoolean rightOperator) => leftOperator.CompareTo(rightOperator) < 0;

    /// <summary>
    /// Implements the operator ==.
    /// </summary>
    /// <param name="leftOperator">The left operator.</param>
    /// <param name="rightOperator">The right operator.</param>
    /// <returns>The result of the operator.</returns>
    public static bool operator <=(PdfBoolean leftOperator, PdfBoolean rightOperator) => leftOperator.CompareTo(rightOperator) <= 0;

    /// <summary>
    /// Implements the operator ==.
    /// </summary>
    /// <param name="leftOperator">The left operator.</param>
    /// <param name="rightOperator">The right operator.</param>
    /// <returns>The result of the operator.</returns>
    public static bool operator >(PdfBoolean leftOperator, PdfBoolean rightOperator) => leftOperator.CompareTo(rightOperator) > 0;

    /// <summary>
    /// Implements the operator ==.
    /// </summary>
    /// <param name="leftOperator">The left operator.</param>
    /// <param name="rightOperator">The right operator.</param>
    /// <returns>The result of the operator.</returns>
    public static bool operator >=(PdfBoolean leftOperator, PdfBoolean rightOperator) => leftOperator.CompareTo(rightOperator) >= 0;

    /// <summary>
    /// Performs an implicit conversion from <see cref="PdfBoolean"/> to <see cref="bool"/>.
    /// </summary>
    /// <param name="pdfBoolean">The Pdf boolean object.</param>
    /// <returns>The result of the conversion.</returns>
    public static implicit operator bool(PdfBoolean pdfBoolean) => pdfBoolean.Value;

    /// <summary>
    /// Performs an implicit conversion from <see cref="bool"/> to <see cref="PdfBoolean"/>.
    /// </summary>
    /// <param name="value">if set to <c>true</c> [value].</param>
    /// <returns>The result of the conversion.</returns>
    public static implicit operator PdfBoolean(bool value) => new(value);
    #endregion

    #region IEquatable implementations
    /// <inheritdoc/>
    public bool Equals(PdfBoolean other) => Value == other.Value;

    /// <inheritdoc/>
    public override bool Equals(object? obj) => (obj is PdfBoolean booleanObject) && Equals(booleanObject);
    #endregion

    #region IComparable implementations
    /// <summary>
    /// Compares the current instance with another object of the same type and returns an integer that
    /// indicates whether the current instance precedes, follows, or occurs in the same position in the sort
    /// order as the other object.
    /// </summary>
    /// <param name="other">An object to compare with this instance.</param>
    /// <returns>A value that indicates the relative order of the objects being compared.</returns>
    public int CompareTo(PdfBoolean other)
    {
        if (Value == other.Value)
        {
            return 0;
        }

        return Value ? 1 : -1;
    }

    /// <summary>
    /// Compares the current instance with another object of the same type and returns an integer that indicates whether
    /// the current instance precedes, follows, or occurs in the same position in the sort order as the other object.
    /// </summary>
    /// <param name="obj">An object to compare with this instance.</param>
    /// <returns>A value that indicates the relative order of the objects being compared.</returns>
    /// <exception cref="ArgumentException"><paramref name="obj" /> is not the same type as this instance.</exception>
    public int CompareTo(object? obj)
    {
        if (obj is not PdfBoolean pdfBoolean)
        {
            throw new ArgumentException("Object must be of PDF Boolean type.");
        }

        return CompareTo(pdfBoolean);
    }
    #endregion
}
