﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace PDFtoPrinter
{
    /// <summary>
    /// Options for a Printer
    /// </summary>
    public class PrintingOptions : IEquatable<PrintingOptions>
    {
        /// <summary>
        /// Creates new <see cref="PrintingOptions"/> instance.
        /// </summary>
        /// <param name="printerName">Name of the printer.</param>
        /// <param name="filePath">Path to the PDF file.</param>
        public PrintingOptions(string printerName, string filePath)
        {
            this.PrinterName = printerName;
            this.FilePath = filePath;
        }

        /// <summary>
        /// Name of the printer (if the printer is network, use network format e.g. "\\printmachine\defaultprinter").
        /// </summary>
        public string PrinterName { get; }

        /// <summary>
        /// Path to the PDF file.
        /// </summary>
        public string FilePath { get; }

        /// <summary>
        /// Page range for printing.
        /// Separate multiple page ranges with commas (no spaces) like this: 2-4,7,12 
        /// or, to specify all pages after a specific page, use its number followed by a hyphen, like this: 7-
        /// </summary>
        public string Pages { get; set; }

        /// <summary>
        /// Number of copies
        /// </summary>
        public uint? Copies { get; set; }

        /// <summary>
        /// Title of the window. The printing program will return keyboard focus to it.
        /// Partial titles will work; you do not need the full title.
        /// </summary>
        public string Focus { get; set; }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as PrintingOptions);
        }

        public virtual bool Equals(PrintingOptions other)
        {
            return other != null &&
                   this.PrinterName == other.PrinterName &&
                   this.FilePath == other.FilePath &&
                   this.Pages == other.Pages &&
                   EqualityComparer<uint?>.Default.Equals(this.Copies, other.Copies) &&
                   this.Focus == other.Focus;
        }

        public override int GetHashCode()
        {
            int hashCode = -1936359086;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(this.PrinterName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(this.FilePath);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(this.Pages);
            hashCode = hashCode * -1521134295 + EqualityComparer<uint?>.Default.GetHashCode(this.Copies);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(this.Focus);
            return hashCode;
        }

        public override string ToString()
        {
            return string.Join(
                " ",
                new[]
                {
                    this.FilePath,
                    this.PrinterName,
                    this.Pages,
                    this.Copies?.ToString(),
                    this.Focus
                }
                .Where(x => !string.IsNullOrEmpty(x))
                .Select(x => $"\"{x}\""));
        }
    }
}
