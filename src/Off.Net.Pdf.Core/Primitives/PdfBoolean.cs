namespace Off.Net.Pdf.Core.Primitives;

using Off.Net.Pdf.Core.Interfaces;

/// <summary>
/// Represents a PDF Boolean object.
/// </summary>
/// <seealso cref="IPdfObject{bool}" />
public struct PdfBoolean : IPdfObject<bool>, IEquatable<PdfBoolean>
{
    private const string FalseLiteral = "false";
    private const string TrueLiteral = "true";
    private static readonly byte[] FalseBytes = new byte[] { 0x66, 0x61, 0x6C, 0x73, 0x65 };
    private static readonly byte[] TrueBytes = new byte[] { 0x74, 0x72, 0x75, 0x65 };

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
    public override int GetHashCode() => Value.GetHashCode();

    /// <inheritdoc/>
    public override string ToString() => Value ? TrueLiteral : FalseLiteral;

    #region Operators
    /// <summary>
    /// Implements the operator !=.
    /// </summary>
    /// <param name="leftOperator">The left operator.</param>
    /// <param name="rightOperator">The right operator.</param>
    /// <returns>
    /// The result of the operator.
    /// </returns>
    public static bool operator !=(PdfBoolean leftOperator, PdfBoolean rightOperator) => !leftOperator.Equals(rightOperator);

    /// <summary>
    /// Implements the operator ==.
    /// </summary>
    /// <param name="leftOperator">The left operator.</param>
    /// <param name="rightOperator">The right operator.</param>
    /// <returns>
    /// The result of the operator.
    /// </returns>
    public static bool operator ==(PdfBoolean leftOperator, PdfBoolean rightOperator) => leftOperator.Equals(rightOperator);

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

    #region Equality checking methods
    /// <inheritdoc/>
    public bool Equals(PdfBoolean other) => Value == other.Value;

    /// <inheritdoc/>
    public override bool Equals(object? obj) => (obj is PdfBoolean booleanObject) && Equals(booleanObject);
    #endregion
}
