using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using teset09062.DAL2;

namespace teset09062.Pages
{
    public class RecordModel : PageModel
    {
        public void OnGet()
        {
        }

        public Record2[] GetRecords()
        {
            RecordManager2 rm = new RecordManager2();
            Record2[] records = rm.GetAllRecords();



            return records;


        }
    }
}
