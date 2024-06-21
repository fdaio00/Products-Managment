using System.Data;

public class clsCategory
{
    private enum enMode { AddNew = 0, Update = 1 };
    enMode _Mode = enMode.AddNew;

    public int CatID { get; set; }
    public string CatDescription { get; set; }

    public clsCategory()
    {
        this.CatID = -1;
        this.CatDescription = "";
        _Mode = enMode.AddNew;
    }

    private clsCategory(int catID, string catDescription)
    {
        _Mode = enMode.Update;
        this.CatID = catID;
        this.CatDescription = catDescription;
    }

    private bool _AddNewCategory()
    {
        this.CatID = clsCategoryData.AddNewCategory(this.CatDescription);
        return (this.CatID != -1);
    }

    private bool _UpdateCategory()
    {
        return clsCategoryData.UpdateCategory(this.CatID, this.CatDescription);
    }

    public bool Save()
    {
        switch (_Mode)
        {
            case enMode.AddNew:
                if (_AddNewCategory())
                {
                    _Mode = enMode.Update;
                    return true;
                }
                else
                {
                    return false;
                }
            case enMode.Update:
                return _UpdateCategory();
            default:
                return false;
        }
    }

    public static DataTable GetAllCategories()
    {
        return clsCategoryData.GetAllCategories();
    }

    public static clsCategory FindCategoryByCatID(int catID)
    {
        string CatDescription = "";
        bool isFound = (clsCategoryData.FindCategoryByCatID(catID, ref CatDescription));
        if (isFound)
        {
            return new clsCategory(catID, CatDescription);
        }
        else
        {
            return null;

        }
    }

    public static clsCategory FindCategoryByCatName(string CatDescription)
    {
        int CatID = -1;
        bool isFound = (clsCategoryData.FindCategoryByCatName(ref CatID, CatDescription));
        if (isFound)
        {
            return new clsCategory(CatID, CatDescription);
        }
        else
        {
            return null;

        }
    }

    public static bool DeleteCategory(int catID)
    {
        return clsCategoryData.DeleteCategory(catID);
    }


}
