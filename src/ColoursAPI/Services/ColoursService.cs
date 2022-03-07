using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using ColoursAPI.Models;

namespace ColoursAPI.Services
{
    public class ColoursService
    {
        private List<ColoursItem> _listColors = new() {  }; 

        public ColoursService(IConfiguration config)
        {
            _ = Reset();

            return;
        }

        public async Task<List<ColoursItem>> GetAll()
        {
            await Task.Run(() => { });

            return _listColors;
        }


        public async Task<ColoursItem> GetById(int id)
        {
            ColoursItem _colourItem = _listColors.Find(x => x.Id == id);

            await Task.Run(() => { });

            return _colourItem;

        }

        public async Task<ColoursItem> GetByName(string pName)
        {
            await Task.Run(() => { });

            ColoursItem _colourItem = null;

            int idxName = _listColors.FindIndex(a => a.Name.ToLower() == pName.ToLower().Trim());
            if (idxName >= 0)
            {
                _colourItem = _listColors[idxName];
            }

            return _colourItem;

        }

        public async Task<ColoursItem> UpdateById(int id, ColoursItem coloursItemUpdate)
        {
            int idx = id;

            int idxName = _listColors.FindIndex(a => a.Name.ToLower() == coloursItemUpdate.Name.ToLower().Trim());
            if (idxName >= 0)
            {
                _listColors.RemoveAt(idxName);
            }

            if (idx > 0)
            {
                int idxId = _listColors.FindIndex(a => a.Id == idx);
                if (idxId >= 0)
                {
                    _listColors.RemoveAt(idxId);
                }
            }
            else
            {
                for (int i = 1; i <= 1000; i++)
                {
                    if (_listColors.Find(x => x.Id == i) == null)
                    {
                        idx = i;
                        break;
                    }
                }
            }

            coloursItemUpdate.Id = idx;
            coloursItemUpdate.Name = coloursItemUpdate.Name.ToLower().Trim();

            _listColors.Add(coloursItemUpdate);

            await Task.Run(() => { });

            return coloursItemUpdate;

        }

        public async Task<ColoursItem> DeleteById(int id)
        {
            int idxId = _listColors.FindIndex(a => a.Id == id);
            if (idxId >= 0)
            {
                _listColors.RemoveAt(idxId);
            }

            await Task.Run(() => { });

            return null;

        }

        public async Task<ColoursItem> DeleteAll()
        {
            _listColors.Clear();

            await Task.Run(() => { });

            return null;

        }

        public async Task<ColoursItem> Reset()
        {
            await DeleteAll();

            await UpdateById(1, new ColoursItem { Id = 1, Name = "Blue", Data = "#0000FF" });
            await UpdateById(2, new ColoursItem { Id = 2, Name = "Navy", Data = "#000080" });
            await UpdateById(3, new ColoursItem { Id = 3, Name = "Olive", Data = "#808000" });
            await UpdateById(4, new ColoursItem { Id = 4, Name = "Green", Data = "#008000" });
            await UpdateById(5, new ColoursItem { Id = 5, Name = "Lime", Data = "#00FF00" });
            await UpdateById(6, new ColoursItem { Id = 6, Name = "Purple", Data = "#800080" });
            await UpdateById(7, new ColoursItem { Id = 7, Name = "Magenta", Data = "#FF00FF" });
            await UpdateById(8, new ColoursItem { Id = 8, Name = "Yellow", Data = "#FFFF00" });
            await UpdateById(9, new ColoursItem { Id = 9, Name = "Coral", Data = "#FF7F50" });
            await UpdateById(10, new ColoursItem { Id = 10, Name = "Red", Data = "#FF0000" });


            return null;

        }

    }
}
