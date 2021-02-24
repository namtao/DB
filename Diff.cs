﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    class Diff
    {
        public string id, so, quyenSo, noiDangKy, ngayDangKy, tableName, columnName, ktbm1, ktbm2, kt;

        public Diff(string id, string so, string quyenSo, string noiDangKy, string ngayDangKy, string tableName, string columnName, string ktbm1, string ktbm2, string kt)
        {
            this.id = id;
            this.so = so;
            this.quyenSo = quyenSo;
            this.noiDangKy = noiDangKy;
            this.ngayDangKy = ngayDangKy;
            this.tableName = tableName;
            this.columnName = columnName;
            this.ktbm1 = ktbm1;
            this.ktbm2 = ktbm2;
            this.kt = kt;
        }

        public Diff()
        {
        }
    }
}
