namespace Off.Net.Pdf.Core.Interfaces;

public interface IPdfObject<T>
{
    /// <summary>
    /// Gets the length of the object.
    /// </summary>
    int Length { get; }

    /// <summary>
    /// Gets or sets the value of the object.
    /// </summary>
    T Value { get; }

    /// <summary>
    /// Gets the bytes array representation of the Pdf object.
    /// </summary>
    byte[] Bytes { get; }
}
