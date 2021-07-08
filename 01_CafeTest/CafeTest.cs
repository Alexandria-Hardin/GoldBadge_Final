using System;
using System.Collections.Generic;
using _01_Cafe;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _01_CafeTest
{
    [TestClass]
    public class MenuRepoTest
    {
        [TestMethod]
        public void AddItemsToMenu_ShouldGetCorrectBool()
        {
            //Arrange
            Menu newContent = new Menu();
            MenuRepository repository = new MenuRepository();
            //Act
            bool addResult = repository.AddItemsToMenus(newContent);
            //Assert 
            Assert.IsTrue(addResult);
        }

        [TestMethod]
        public void ShowAllMenuItems_ShouldReturnCorrectList()
        {
            Menu testContent = new Menu();
            MenuRepository repo = new MenuRepository();
            repo.AddItemsToMenus(testContent);
            List<Menu> contents = repo.GetItems();
            bool listHasContent = contents.Contains(testContent);
            Assert.IsTrue(listHasContent);
        }

        private Menu _content;
        private MenuRepository _repo;
        [TestInitialize]
        public void Arrange()
        {//put in argument
            _content = new Menu(1,"chicken sandwich", "sandwich with fries", 5.50m);
            _repo = new MenuRepository();
            _repo.AddItemsToMenus(_content);
        }

        [TestMethod]
        public void GetByName_ShouldReturnCorrectContent()
        {
            Menu searchResult = _repo.GetItemsByName("chicken sandwich");
            Assert.AreEqual(_content.MealName, searchResult.MealName);
        }

        [TestMethod]
        public void DeleteExistingItems_ShouldReturnTrue()
        {
            Menu foundContent = _repo.GetItemsByName("chicken sandwich");
            bool removeResult = _repo.DeleteExistingItems(foundContent);
            Assert.IsTrue(removeResult);
        }
    }
}
