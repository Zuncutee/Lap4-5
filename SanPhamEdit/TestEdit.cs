namespace SanPhamEdit
{
    public class Tests
    {
        private SanPhamService _service;

        [SetUp]
        public void SetUp()
        {
            _service = new SanPhamService();
            _service.Add(new SanPham("1", "SP001", "San Pham 1", 1000, "Do", "L", 10));
        }

        [Test]
        public void SuaSanPham()
        {
            _service.Edit("1", "SP002", "San Pham Moi", 1200, "Xanh", "M", 20);
            var sanPham = _service.GetSanPhamById("1");
            Assert.AreEqual("SP002", sanPham.MaSanPham);
            Assert.AreEqual("San Pham Moi", sanPham.TenSanPham);
        }

        [Test]
        public void SuaSanPham_VoiMaSanPhamKhongBatDauBangSP()
        {
            Assert.Throws<ArgumentException>(() => _service.Edit("1", "12345", "San Pham Moi", 1200, "Xanh", "M", 20));
        }

        [Test]
        public void SuaSanPham_VoiMaSanPhamTrung()
        {
            _service.Add(new SanPham("2", "SP003", "San Pham 2", 1500, "Trang", "S", 30));
            Assert.Throws<ArgumentException>(() => _service.Edit("1", "SP003", "San Pham Moi", 1200, "Xanh", "M", 20));
        }

        [Test]
        public void SuaSanPham_VoiIdKhongTonTai()
        {
            Assert.Throws<ArgumentException>(() => _service.Edit("99", "SP004", "San Pham Moi", 1200, "Xanh", "M", 20));
        }

        [Test]
        public void SuaSanPham2()
        {
            _service.Edit("1", "SP005", "San Pham Moi", 2000, "Den", "L", 15);
            var sanPham = _service.GetSanPhamById("1");
            Assert.AreEqual("SP005", sanPham.MaSanPham);
            Assert.AreEqual(2000, sanPham.Gia);
        }
    }
}