﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace ExcelDna.Integration.Abstractions
{
    public class ExcelReferenceWrapper : ExcelReferenceBase
    {
        private readonly ExcelReference _excelReference;

        public ExcelReferenceWrapper(ExcelReference excelReference)
        {
            if (excelReference == null)
            {
                throw new ArgumentNullException(nameof(excelReference));
            }

            this._excelReference = new ExcelReference(
                excelReference.RowFirst,
                excelReference.RowLast,
                excelReference.ColumnFirst,
                excelReference.ColumnLast,
                excelReference.SheetId);
        }

        public ExcelReferenceWrapper(int row, int column)
        {
            _excelReference = new ExcelReference(row, column);
        }
        
        public ExcelReferenceWrapper(int rowFirst, int rowLast, int columnFirst, int columnLast)
        {
            _excelReference = new ExcelReference(rowFirst, rowLast, columnFirst, columnLast);
        }
        
        public ExcelReferenceWrapper(int rowFirst, int rowLast, int columnFirst, int columnLast, IntPtr sheetId)
        {
            _excelReference = new ExcelReference(rowFirst, rowLast, columnFirst, columnLast, sheetId);
        }

        public ExcelReferenceWrapper(int rowFirst, int rowLast, int columnFirst, int columnLast, string sheetName)
        {
            _excelReference = new ExcelReference(rowFirst, rowLast, columnFirst, columnLast, sheetName);
        }

        [Obsolete("An ExcelReference should never be modified.")]
        public override void AddReference(int rowFirst, int rowLast, int columnFirst, int columnLast)
        {
            _excelReference.AddReference(rowFirst, rowLast, columnFirst, columnLast);
        }

        public override object GetValue()
        {
            return _excelReference.GetValue();
        }

        public override bool SetValue(object value)
        {
            return _excelReference.SetValue(value);
        }

        public override int RowFirst => _excelReference.RowFirst;

        public override int RowLast => _excelReference.RowLast;

        public override int ColumnFirst => _excelReference.ColumnFirst;

        public override int ColumnLast => _excelReference.ColumnLast;

        public override IntPtr SheetId => _excelReference.SheetId;

        public override List<IExcelReference> InnerReferences
        {
            get
            {
                return _excelReference.InnerReferences
                    .Select(r => (IExcelReference)new ExcelReferenceWrapper(r))
                    .ToList();
            }
        }
    }
}