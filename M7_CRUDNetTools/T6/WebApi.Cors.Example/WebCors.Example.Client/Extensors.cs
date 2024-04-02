namespace WebCors.Example.Client
{
    public static class Extensors
    {
        public static Boolean IsNullOrEmpty(this String Expr)
        {
            Boolean result = String.IsNullOrEmpty(Expr);

            return result;
        }

        public static Int64 ToInt64(this String Expr, Int64 DefautValue = 0)
        {
            return ToInt64Nullable(Expr) ?? DefautValue;
        }

        public static Int64? ToInt64Nullable(this String Expr)
        {
            Int64? result = null;

            if (Expr.IsNullOrEmpty())
                return result;

            Expr = Expr.Trim();

            Int64 newInt64;

            if (Int64.TryParse(Expr, out newInt64))
                result = newInt64;

            return result;
        }

        public static DateTime ToUnixEpochDate(this Int64 unixTime)
        {
            var result = new DateTime(1978, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(unixTime);

            return result;
        }
    }
}
