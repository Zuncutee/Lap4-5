namespace Bai2
{
    public class Tests
    {
        private ItemManager _itemManager;

        [SetUp]
        public void SetUp()
        {
            _itemManager = new ItemManager();
        }

        [Test]
        public void AddItem()
        {
            var item = new Item(1, "ValidName");
            _itemManager.AddItem(item);
            Assert.AreEqual(1, _itemManager.Items.Count);
            Assert.AreEqual("ValidName", _itemManager.Items[0].Name);
        }

        [Test]
        public void AddItem_NameHon50()
        {
            var item = new Item(1, new string('a', 51)); // Tên dài hơn 50 ký tự
            Assert.Throws<ArgumentException>(() => _itemManager.AddItem(item));
        }

        [Test]
        public void UpdateItem()
        {
            var item = new Item(1, "OldName");
            _itemManager.AddItem(item);
            _itemManager.UpdateItem(1, "NewName");
            Assert.AreEqual("NewName", _itemManager.Items[0].Name);
        }

        [Test]
        public void UpdateItem_NameHon50()
        {
            var item = new Item(1, "OldName");
            _itemManager.AddItem(item);
            Assert.Throws<ArgumentException>(() => _itemManager.UpdateItem(1, new string('a', 51)));
        }

        [Test]
        public void DeleteItem()
        {
            var item = new Item(1, "ToDelete");
            _itemManager.AddItem(item);
            _itemManager.DeleteItem(1);
            Assert.AreEqual(0, _itemManager.Items.Count);
        }
    }
}