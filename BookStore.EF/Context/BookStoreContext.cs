using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Auth.Entity;
using BookStore.Catalog.Entity;
using BookStore.News.Entity;
using Microsoft.EntityFrameworkCore;

namespace BookStore.EF.Context
{
    public class BookStoreContext : DbContext
    {
        public DbSet<NewsEntity> News { get; set; }

        public DbSet<UserEntity> Users { get; set; }

        public DbSet<BookEntity> Books { get; set; }

        public DbSet<ManagerEntity> Managers { get; set; }

        public DbSet<DepartmentEntity> Departments { get; set; }

        public DbSet<StoreEntity> Stores { get; set; }

        public BookStoreContext(DbContextOptions<BookStoreContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<BookEntity>()
                    .HasMany(e => e.Departments)
                    .WithMany(e => e.Books)
                    .UsingEntity<DepartmentEntity>();

            var newsList = new List<NewsEntity>()
            {
                new NewsEntity(){ Id = 1, DateCreate = DateTime.Now.AddDays(-2), PathToImage = "~/images/newsImages/1.jpg", Content = "Сентябрь 2023. Выпуск №3 Это интересно 1. Литературный тиндер: любовь в советскую и постсоветскую эпохи. Мы пофантазировали о том, как выглядели бы профили персонажей советских и современных российских писателей в дейтингах, и как сложились бы их отношения, если они нашли бы друг друга именно там. 2. Что мир читал в 1865 году? Пришествие Алисы и полет на Луну. В этом году читателю выпало свести знакомство с целым рядом очень интересных книг самого разного жанра. И с целым рядом авторов, о которых он раньше и не слышал. 3. Почему из «Смертельного образования» получилось бы классное аниме. Смертельно опасная школа волшебников, подростки"},
                new NewsEntity(){ Id = 2, DateCreate = DateTime.Now.AddDays(-3), PathToImage = "~/images/newsImages/2.jpg", Content = "В день рождения великого языковеда Сергея Ивановича Ожегова, составителя одного из самых популярных толковых словарей, мы с вами ненадолго перенесемся в прошлое и проверим знание старинных или вышедших из употребления слов. Пройти тест"},
                new NewsEntity(){ Id = 3, DateCreate = DateTime.Now.AddDays(-4), PathToImage = "~/images/newsImages/3.jpg", Content = "В современном мире множество причин для тревог: нелюбимая работа, вынужденный переезд, утрата  близких... Неисчерпаемый колодезь личных проблем — неспособность принять себя, синдром самозванца, страх совершить ошибку и многое, многое другое. Новая книга психолога Ольги Примаченко, автора бестселлера «К себе нежно», послужит лекарством для ран и тревог. Конечно, нет универсального рецепта для всех на свете проблем, зато можно научиться верить себе, спокойно воспринимать окружающий мир и строить жизнь так, как хочется нам, а не так, как диктуют другие. Ольга Примаченко - Всё закончится, а ты нет. "},
                new NewsEntity(){ Id = 4, DateCreate = DateTime.Now.AddDays(-5), PathToImage = "~/images/newsImages/4.jpg", Content = "С прошлого ноября, как и каждый предыдущий год, Шведская академия получает тысячи писем в поддержку авторов, как признанных, так и малоизвестных, претендующих на Нобелевскую премию. Такие номинации могут быть сделаны только квалифицированными номинаторами. Кто обладает правом номинировать кандидатов на Нобелевскую премию: 1. Члены Шведской академии и других академий, институтов и обществ, сходных с ней по структуре и назначению. 2. Профессора литературы и лингвистики в университетах и колледжах. 3. Предыдущие лауреаты Нобелевской премии по литературе."},
                new NewsEntity(){ Id = 5, DateCreate = DateTime.Now.AddDays(-6), PathToImage = "~/images/newsImages/5.jpg", Content = "Сегодня признанному Королю Ужасов исполняется 76 лет, и мы попросили нашего колумниста Энджи Эфенди раскрыть тайны такой притягательности прозы этого великого автора. Впервые я прочитала рассказ Кинга в девять лет в «Антологии современного американского рассказа». Никак не ожидала от смирной советской книжки, где обычно печатались истории с социальным подтекстом, и от рассказа с милым названием «Дети кукурузы» такой подставы. Потом уже стали появляться на прилавках книги Кинга в жутковатых (но креативных) обложках 90-х годов, и я узнала, насколько популярный он автор."},
            };

            var userList = new List<UserEntity>()
            {
                new UserEntity(){ Id = 1, Login = "user1", Password = "user1", Name = "User1", Role = UserRole.User },
                new UserEntity(){ Id = 2, Login = "user2", Password = "user2", Name = "User2", Role = UserRole.User },
                new UserEntity(){ Id = 3, Login = "user3", Password = "user3", Name = "User3", Role = UserRole.User },
                new UserEntity(){ Id = 4, Login = "admin1", Password = "admin1", Name = "Admin1", Role = UserRole.Admin },
            };

            var bookList = new List<BookEntity>()
            {
                new BookEntity(){ Id = 1, Name = "Граф Аверин. Колдун Российской империи", PathToImage = "~/images/catalogImages/1.jpg", Genre = Genres.Prose, Price = 550, PageCount = 320 },
                new BookEntity(){ Id = 2, Name = "Портрет Дориана Грея", PathToImage = "~/images/catalogImages/2.jpg", Genre = Genres.Foreign, Price = 690, PageCount =  480},
                new BookEntity(){ Id = 3, Name = "Ваш покорный слуга кот", PathToImage = "~/images/catalogImages/3.jpg", Genre = Genres.Fantasy, Price = 480, PageCount = 120 },
                new BookEntity(){ Id = 4, Name = "1984 (новый перевод)", PathToImage = "~/images/catalogImages/4.jpg", Genre = Genres.Fantasy, Price = 550, PageCount = 370 },
                new BookEntity(){ Id = 5, Name = "Триумфальная арка", PathToImage = "~/images/catalogImages/9.jpg", Genre = Genres.Prose, Price = 440, PageCount = 390 },
                new BookEntity(){ Id = 6, Name = "На Западном фронте без перемен", PathToImage = "~/images/catalogImages/5.jpg", Genre = Genres.Prose, Price = 500, PageCount = 280 },
                new BookEntity(){ Id = 7, Name = "Грозовой перевал", PathToImage = "~/images/catalogImages/6.jpg", Genre = Genres.Fantasy, Price = 380, PageCount = 410 },
                new BookEntity(){ Id = 8, Name = "Клуб самоубийц", PathToImage = "~/images/catalogImages/7.jpg", Genre = Genres.Prose, Price = 570, PageCount = 410 },
                new BookEntity(){ Id = 9, Name = "Мартин Иден", PathToImage = "~/images/catalogImages/8.jpg", Genre = Genres.Foreign, Price = 410, PageCount = 380 },
                new BookEntity(){ Id = 10, Name = "Маленький принц", PathToImage = "~/images/catalogImages/10.jpg", Genre = Genres.Foreign, Price = 600, PageCount = 230 },
                new BookEntity(){ Id = 11, Name = "Отцы и дети", PathToImage = "~/images/catalogImages/11.jpg", Genre = Genres.Domestic, Price = 380, PageCount =  510},
                new BookEntity(){ Id = 12, Name = "Работа легкой не бывает", PathToImage = "~/images/catalogImages/12.jpg", Genre = Genres.PopularScience, Price = 750, PageCount = 300 },
            };

            var manager1 = new ManagerEntity() { Id = 1, Name = "Валиев Антон Дмитриевич", Mail = "khabfafkjhb@gmail.com", Number = "898249553535" };
            var manager2 = new ManagerEntity() { Id = 2, Name = "Полынский Арсений Андреевич", Mail = "akjbfkabfjhabf@gmail.com", Number = "898005553536" };
            var manager3 = new ManagerEntity() { Id = 3, Name = "Рогожников Даниил Владимирович", Mail = "1894bafbahfbj@gmail.com", Number = "898005553535" };

            var listDepartment = new List<DepartmentEntity>()
            {
                new DepartmentEntity() { Id = 1, Manager = manager1},
                new DepartmentEntity() { Id = 2, Manager = manager2},
                new DepartmentEntity() { Id = 3, Manager = manager3},
            };

            for (int i = 0; i < bookList.Count - 1; i++)
            {
                bookList[i].Stores.Add(new StoreEntity() { Department = listDepartment[i % 3], BookCount = new Random().Next(2, 50) });
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
