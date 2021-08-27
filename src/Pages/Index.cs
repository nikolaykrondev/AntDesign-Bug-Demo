using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AntDesign;
using AntDesignBugDemo.Models;

namespace AntDesignBugDemo.Pages
{
    public partial class Index
    {
        public List<DemoTestData> TestDataDataSource { get; set; }
        
        private IEnumerable<DemoTestData> _selectedRows;
        private TableFilter<string>[] _nameFilter;
        private ITable _table;

        protected override Task OnInitializedAsync()
        {
            TestDataDataSource = new()
            {
                new() { Id = 1, Name = "First" },
                new() { Id = 2, Name = "Second" },
            };
            _selectedRows = Enumerable.Empty<DemoTestData>();
            CreateFilters();
            return base.OnInitializedAsync();
        }
        
        private void CreateFilters()
        {
            _nameFilter = TestDataDataSource
                .Where(a => !string.IsNullOrEmpty(a.Name))
                .Select(a => a.Name)
                .Distinct()
                .Select(c => new TableFilter<string>
                {
                    Text = c,
                    Value = c
                }).ToArray();
        }
    }
}