using System.Collections.Generic;
using doan.Models;

public interface IVocabularyRepository
{
    List<Bai01Model> GetAll();
    Bai01Model GetByID(int id);
    void Update(Bai01Model vocab);
    void Save();
}