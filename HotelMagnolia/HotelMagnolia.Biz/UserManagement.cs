using HotelMagnolia.DB;

namespace HotelMagnolia.Biz
{
    public class UserManagement
    {
        public void juanito()
        {
            using (var db = new HotelMagnoliaDb())
            {
                db.CONSECUTIVOes.Add(new CONSECUTIVO
                {
                    ID_CONSECUTIVOS = 1,
                });
            }
        }
    }
}