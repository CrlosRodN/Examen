using DataAcess.Dao;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.Mapper
{
    public class CreditoMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        private const string DB_COL_ID = "ID";
        private const string DB_COL_MONTO = "MONTO";
        private const string DB_COL_TASA = "TASA";
        private const string DB_COL_NOMBRE = "NOMBRE";
        private const string DB_COL_CUOTA = "CUOTA";
        private const string DB_COL_FECHA_INICIO = "FECHA_INICIO";
        private const string DB_COL_ESTADO = "ESTADO";
        private const string DB_COL_SALDO = "SALDO";

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_CREDIT_PR" };

            var c = (Credito)entity;
            operation.AddVarcharParam(DB_COL_ID, c.id);
            operation.AddDoubleParam(DB_COL_MONTO, c.monto);
            operation.AddDoubleParam(DB_COL_TASA, c.tasa);
            operation.AddVarcharParam(DB_COL_NOMBRE, c.nombre);
            operation.AddDoubleParam(DB_COL_CUOTA, c.cuota);
            operation.AddDateParam(DB_COL_FECHA_INICIO, c.fechaInicio);
            operation.AddVarcharParam(DB_COL_ESTADO, c.estado);
            operation.AddDoubleParam(DB_COL_SALDO, c.saldo);

            return operation;
        }


        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_CREDIT_PR" };

            var c = (Credito)entity;
            operation.AddVarcharParam(DB_COL_ID, c.id);

            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_CREDIT_PR" };
            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_CREDIT_PR" };

            var c = (Credito)entity;
            operation.AddVarcharParam(DB_COL_ID, c.id);
            operation.AddDoubleParam(DB_COL_MONTO, c.monto);
            operation.AddDoubleParam(DB_COL_TASA, c.tasa);
            operation.AddVarcharParam(DB_COL_NOMBRE, c.nombre);
            operation.AddDoubleParam(DB_COL_CUOTA, c.cuota);
            operation.AddDateParam(DB_COL_FECHA_INICIO, c.fechaInicio);
            operation.AddVarcharParam(DB_COL_ESTADO, c.estado);
            operation.AddDoubleParam(DB_COL_SALDO, c.saldo);

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_CREDIT_PR" };

            var c = (Credito)entity;
            operation.AddVarcharParam(DB_COL_ID, c.id);
            return operation;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var customer = BuildObject(row);
                lstResults.Add(customer);
            }

            return lstResults;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var credito = new Credito
            {
                id = GetStringValue(row, DB_COL_ID),
                monto = GetDoubleValue(row, DB_COL_MONTO),
                tasa = GetDoubleValue(row, DB_COL_TASA),
                nombre = GetStringValue(row, DB_COL_NOMBRE),
                cuota = GetDoubleValue(row, DB_COL_CUOTA),
                fechaInicio = GetDateValue(row, DB_COL_FECHA_INICIO),
                estado = GetStringValue(row, DB_COL_ESTADO),
                saldo = GetDoubleValue(row, DB_COL_SALDO)
            };

            return credito;
        }

    }
}
