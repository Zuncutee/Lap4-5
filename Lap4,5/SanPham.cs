namespace Lap4_5
{
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
    }

    [TestFixture]
    public class TestAdd
    {
        private SanPhamService _service;

        [SetUp]
        public void SetUp()
        {
            _service = new SanPhamService();
        }

        [Test]
        public void ThemSanPham()
        {
            var sanPham = new SanPham("1", "SP001", "San Pham 1", 1000, "Do", "L", 10);
            _service.Add(sanPham);
            Assert.AreEqual(1, _service.GetAllSanPham().Count);
        }

        [Test]
        public void ThemSanPham_VoiSoLuongBang0()
        {
            var sanPham = new SanPham("2", "SP002", "San Pham 2", 2000, "Xanh", "M", 0);
            Assert.Throws<ArgumentException>(() => _service.Add(sanPham));
        }

        [Test]
        public void ThemSanPham_VoiSoLuongAm()
        {
            var sanPham = new SanPham("3", "SP003", "San Pham 3", 1500, "Trang", "S", -5);
            Assert.Throws<ArgumentException>(() => _service.Add(sanPham));
        }

        [Test]
        public void ThemSanPham_VoiSoLuongBang100()
        {
            var sanPham = new SanPham("4", "SP004", "San Pham 4", 3000, "Den", "XL", 100);
            Assert.Throws<ArgumentException>(() => _service.Add(sanPham));
        }

        [Test]
        public void ThemSanPham_VoiSoLuongGan100()
        {
            var sanPham = new SanPham("5", "SP005", "San Pham 5", 2500, "Vang", "M", 99);
            _service.Add(sanPham);
            Assert.AreEqual(1, _service.GetAllSanPham().Count);
        }
    }
}