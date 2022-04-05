using Books.Data;
using Books.DataServices;
using Microsoft.AspNetCore.Components;

namespace Books.WebApp.Pages.BookPages
{

    public partial class List
    {
        [Inject]
        private IBookDataService BookDataService { get; set; }

        public IEnumerable<Book> Books { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Books = await BookDataService.GetAllBooks();
        }

    }

}
