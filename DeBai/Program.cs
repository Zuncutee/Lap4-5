// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


//Lab 4 + 5 
// 1, Tạo class SanPham gồm các thuộc tính: id - String, maSanPham - String, tenSanPham - String, gia - float, mauSac - String, kichThuoc - String, soLuong - int  và các constructor getter setter 
//Tạo class SanPhamService viết các hàm thêm, sửa, xóa

//Sử dụng đúng thư viện cần thiết để viết unit test(JUnit/Nunit) và thực hiện các yêu cầu sau :

//Áp dụng các kỹ thuật test đã học: Kỹ thuật biên hãy viết unit test cho chức năng “Thêm” 1 đối tượng (ít nhất 5 unit test).
//Kiểm tra các dữ liệu sau: số lượng phải là số nguyên dương và nhỏ hơn 100 

//Áp dụng các kỹ thuật test đã học: Kỹ thuật đoán lỗi hãy viết unit test cho chức năng “Sửa” 1 đối tượng. (ít nhất 5 unit test)
// Kiểm tra các dữ liệu sau: mã sản phẩm là duy nhất và bắt đầu là SP ít nhất 5 unit test 
public class SanPham
{
    public string Id { get; set; }
    public string MaSanPham { get; set; }
    public string TenSanPham { get; set; }
    public float Gia { get; set; }
    public string MauSac { get; set; }
    public string KichThuoc { get; set; }
    public int SoLuong { get; set; }

    public SanPham(string id, string maSanPham, string tenSanPham, float gia, string mauSac, string kichThuoc, int soLuong)
    {
        Id = id;
        MaSanPham = maSanPham;
        TenSanPham = tenSanPham;
        Gia = gia;
        MauSac = mauSac;
        KichThuoc = kichThuoc;
        SoLuong = soLuong;
    }
}
public class SanPhamService
{
    private List<SanPham> _sanPhams = new List<SanPham>();

    public void Add(SanPham sanPham)
    {
        if (sanPham.SoLuong <= 0 || sanPham.SoLuong >= 100)
        {
            throw new ArgumentException("Số lượng phải là số nguyên dương và nhỏ hơn 100.");
        }
        _sanPhams.Add(sanPham);
    }

    public List<SanPham> GetAllSanPham()
    {
        return _sanPhams;
    }

    public void Edit(string id, string maSanPhamMoi, string tenSanPhamMoi, float giaMoi, string mauSacMoi, string kichThuocMoi, int soLuongMoi)
    {
        var sanPham = _sanPhams.FirstOrDefault(sp => sp.Id == id);
        if (sanPham == null)
        {
            throw new ArgumentException("Không tìm thấy sản phẩm với ID này.");
        }

        if (maSanPhamMoi.StartsWith("SP") == false)
        {
            throw new ArgumentException("Mã sản phẩm phải bắt đầu bằng 'SP'.");
        }

        if (_sanPhams.Any(sp => sp.MaSanPham == maSanPhamMoi && sp.Id != id))
        {
            throw new ArgumentException("Mã sản phẩm phải là duy nhất.");
        }

        sanPham.MaSanPham = maSanPhamMoi;
        sanPham.TenSanPham = tenSanPhamMoi;
        sanPham.Gia = giaMoi;
        sanPham.MauSac = mauSacMoi;
        sanPham.KichThuoc = kichThuocMoi;
        sanPham.SoLuong = soLuongMoi;
    }

    public SanPham GetSanPhamById(string id)
    {
        return _sanPhams.FirstOrDefault(sp => sp.Id == id);
    }
}


//Bài2 :Áp dụng các kỹ thuật test đã học: Phân vùng tương đương/kỹ thuật biên, hãy viết unit test cho chức năng “Thêm, Sửa, Xóa” ở đoạn code trên.
//Kiểm tra name phải là chữ và có độ dài nhỏ hơn 50

public class Item
{
    public int Id { get; set; }
    public string Name { get; set; }

    public Item(int id, string name)
    {
        Id = id;
        Name = name;
    }
}


public class ItemManager
{
    private List<Item> items = new List<Item>();
    public IReadOnlyList<Item> Items => items;
    public List<Item> GetItems()
    {
        return items;
    }
    public void AddItem(Item item)
    {
        if (item.Name.Length > 50)
        {
            throw new ArgumentException("name phải là chữ và có độ dài nhỏ hơn 50.");
        }
        items.Add(item);
    }

    public void UpdateItem(int id, string newName)
    {
        if (newName.Length > 50)
        {
            throw new ArgumentException("name phải là chữ và có độ dài nhỏ hơn 50.");
        }
        var item = items.FirstOrDefault(i => i.Id == id);
        if (item != null)
        {
            item.Name = newName;
        }
    }

    public void DeleteItem(int id)
    {
        items.RemoveAll(i => i.Id == id);
    }
}
