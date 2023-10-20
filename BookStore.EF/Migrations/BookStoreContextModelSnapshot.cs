﻿// <auto-generated />
using System;
using BookStore.EF.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BookStore.EF.Migrations
{
    [DbContext(typeof(BookStoreContext))]
    partial class BookStoreContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BookStore.Auth.Entity.UserEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Login")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<byte>("Role")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Login = "user1",
                            Name = "User1",
                            Password = "user1",
                            Role = (byte)2
                        },
                        new
                        {
                            Id = 2,
                            Login = "user2",
                            Name = "User2",
                            Password = "user2",
                            Role = (byte)2
                        },
                        new
                        {
                            Id = 3,
                            Login = "user3",
                            Name = "User3",
                            Password = "user3",
                            Role = (byte)2
                        },
                        new
                        {
                            Id = 4,
                            Login = "admin1",
                            Name = "Admin1",
                            Password = "admin1",
                            Role = (byte)1
                        });
                });

            modelBuilder.Entity("BookStore.Catalog.Entity.BookEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<byte>("Genre")
                        .HasColumnType("smallint");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("PageCount")
                        .HasColumnType("integer");

                    b.Property<string>("PathToImage")
                        .HasColumnType("text");

                    b.Property<double>("Price")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Genre = (byte)2,
                            Name = "Граф Аверин. Колдун Российской империи",
                            PageCount = 320,
                            PathToImage = "~/images/catalogImages/1.jpg",
                            Price = 550.0
                        },
                        new
                        {
                            Id = 2,
                            Genre = (byte)4,
                            Name = "Портрет Дориана Грея",
                            PageCount = 480,
                            PathToImage = "~/images/catalogImages/2.jpg",
                            Price = 690.0
                        },
                        new
                        {
                            Id = 3,
                            Genre = (byte)1,
                            Name = "Ваш покорный слуга кот",
                            PageCount = 120,
                            PathToImage = "~/images/catalogImages/3.jpg",
                            Price = 480.0
                        },
                        new
                        {
                            Id = 4,
                            Genre = (byte)1,
                            Name = "1984 (новый перевод)",
                            PageCount = 370,
                            PathToImage = "~/images/catalogImages/4.jpg",
                            Price = 550.0
                        },
                        new
                        {
                            Id = 5,
                            Genre = (byte)2,
                            Name = "Триумфальная арка",
                            PageCount = 390,
                            PathToImage = "~/images/catalogImages/9.jpg",
                            Price = 440.0
                        },
                        new
                        {
                            Id = 6,
                            Genre = (byte)2,
                            Name = "На Западном фронте без перемен",
                            PageCount = 280,
                            PathToImage = "~/images/catalogImages/5.jpg",
                            Price = 500.0
                        },
                        new
                        {
                            Id = 7,
                            Genre = (byte)1,
                            Name = "Грозовой перевал",
                            PageCount = 410,
                            PathToImage = "~/images/catalogImages/6.jpg",
                            Price = 380.0
                        },
                        new
                        {
                            Id = 8,
                            Genre = (byte)2,
                            Name = "Клуб самоубийц",
                            PageCount = 410,
                            PathToImage = "~/images/catalogImages/7.jpg",
                            Price = 570.0
                        },
                        new
                        {
                            Id = 9,
                            Genre = (byte)4,
                            Name = "Мартин Иден",
                            PageCount = 380,
                            PathToImage = "~/images/catalogImages/8.jpg",
                            Price = 410.0
                        },
                        new
                        {
                            Id = 10,
                            Genre = (byte)4,
                            Name = "Маленький принц",
                            PageCount = 230,
                            PathToImage = "~/images/catalogImages/10.jpg",
                            Price = 600.0
                        },
                        new
                        {
                            Id = 11,
                            Genre = (byte)5,
                            Name = "Отцы и дети",
                            PageCount = 510,
                            PathToImage = "~/images/catalogImages/11.jpg",
                            Price = 380.0
                        },
                        new
                        {
                            Id = 12,
                            Genre = (byte)3,
                            Name = "Работа легкой не бывает",
                            PageCount = 300,
                            PathToImage = "~/images/catalogImages/12.jpg",
                            Price = 750.0
                        });
                });

            modelBuilder.Entity("BookStore.Catalog.Entity.DepartmentEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<int>("ManagerEntityId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ManagerEntityId")
                        .IsUnique();

                    b.ToTable("Departments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Цемлянская, 23",
                            ManagerEntityId = 1
                        },
                        new
                        {
                            Id = 2,
                            Address = "Братская, 77",
                            ManagerEntityId = 2
                        },
                        new
                        {
                            Id = 3,
                            Address = "Ленина, 12",
                            ManagerEntityId = 3
                        });
                });

            modelBuilder.Entity("BookStore.Catalog.Entity.ManagerEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Mail")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Number")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Managers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Mail = "khabfafkjhb@gmail.com",
                            Name = "Валиев Антон Дмитриевич",
                            Number = "898249553535"
                        },
                        new
                        {
                            Id = 2,
                            Mail = "akjbfkabfjhabf@gmail.com",
                            Name = "Полынский Арсений Андреевич",
                            Number = "898005553536"
                        },
                        new
                        {
                            Id = 3,
                            Mail = "1894bafbahfbj@gmail.com",
                            Name = "Рогожников Даниил Владимирович",
                            Number = "898005553535"
                        });
                });

            modelBuilder.Entity("BookStore.Catalog.Entity.StoreEntity", b =>
                {
                    b.Property<int>("DepartmentEntityId")
                        .HasColumnType("integer");

                    b.Property<int>("BookEntityId")
                        .HasColumnType("integer");

                    b.Property<int>("BookCount")
                        .HasColumnType("integer");

                    b.HasKey("DepartmentEntityId", "BookEntityId");

                    b.HasIndex("BookEntityId");

                    b.ToTable("Stores", (string)null);

                    b.HasData(
                        new
                        {
                            DepartmentEntityId = 1,
                            BookEntityId = 1,
                            BookCount = 50
                        },
                        new
                        {
                            DepartmentEntityId = 2,
                            BookEntityId = 2,
                            BookCount = 30
                        },
                        new
                        {
                            DepartmentEntityId = 3,
                            BookEntityId = 3,
                            BookCount = 27
                        },
                        new
                        {
                            DepartmentEntityId = 1,
                            BookEntityId = 4,
                            BookCount = 18
                        },
                        new
                        {
                            DepartmentEntityId = 2,
                            BookEntityId = 5,
                            BookCount = 99
                        },
                        new
                        {
                            DepartmentEntityId = 3,
                            BookEntityId = 6,
                            BookCount = 56
                        },
                        new
                        {
                            DepartmentEntityId = 1,
                            BookEntityId = 7,
                            BookCount = 57
                        },
                        new
                        {
                            DepartmentEntityId = 2,
                            BookEntityId = 8,
                            BookCount = 58
                        },
                        new
                        {
                            DepartmentEntityId = 3,
                            BookEntityId = 9,
                            BookCount = 12
                        },
                        new
                        {
                            DepartmentEntityId = 1,
                            BookEntityId = 10,
                            BookCount = 14
                        },
                        new
                        {
                            DepartmentEntityId = 2,
                            BookEntityId = 11,
                            BookCount = 15
                        },
                        new
                        {
                            DepartmentEntityId = 3,
                            BookEntityId = 12,
                            BookCount = 3
                        });
                });

            modelBuilder.Entity("BookStore.News.Entity.NewsEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .HasColumnType("text");

                    b.Property<DateTime>("DateCreate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("PathToImage")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("News");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Content = "Сентябрь 2023. Выпуск №3 Это интересно 1. Литературный тиндер: любовь в советскую и постсоветскую эпохи. Мы пофантазировали о том, как выглядели бы профили персонажей советских и современных российских писателей в дейтингах, и как сложились бы их отношения, если они нашли бы друг друга именно там. 2. Что мир читал в 1865 году? Пришествие Алисы и полет на Луну. В этом году читателю выпало свести знакомство с целым рядом очень интересных книг самого разного жанра. И с целым рядом авторов, о которых он раньше и не слышал. 3. Почему из «Смертельного образования» получилось бы классное аниме. Смертельно опасная школа волшебников, подростки",
                            DateCreate = new DateTime(2023, 10, 18, 7, 54, 28, 550, DateTimeKind.Utc).AddTicks(9050),
                            PathToImage = "~/images/newsImages/1.jpg"
                        },
                        new
                        {
                            Id = 2,
                            Content = "В день рождения великого языковеда Сергея Ивановича Ожегова, составителя одного из самых популярных толковых словарей, мы с вами ненадолго перенесемся в прошлое и проверим знание старинных или вышедших из употребления слов. Пройти тест",
                            DateCreate = new DateTime(2023, 10, 17, 7, 54, 28, 550, DateTimeKind.Utc).AddTicks(9056),
                            PathToImage = "~/images/newsImages/2.jpg"
                        },
                        new
                        {
                            Id = 3,
                            Content = "В современном мире множество причин для тревог: нелюбимая работа, вынужденный переезд, утрата  близких... Неисчерпаемый колодезь личных проблем — неспособность принять себя, синдром самозванца, страх совершить ошибку и многое, многое другое. Новая книга психолога Ольги Примаченко, автора бестселлера «К себе нежно», послужит лекарством для ран и тревог. Конечно, нет универсального рецепта для всех на свете проблем, зато можно научиться верить себе, спокойно воспринимать окружающий мир и строить жизнь так, как хочется нам, а не так, как диктуют другие. Ольга Примаченко - Всё закончится, а ты нет. ",
                            DateCreate = new DateTime(2023, 10, 16, 7, 54, 28, 550, DateTimeKind.Utc).AddTicks(9057),
                            PathToImage = "~/images/newsImages/3.jpg"
                        },
                        new
                        {
                            Id = 4,
                            Content = "С прошлого ноября, как и каждый предыдущий год, Шведская академия получает тысячи писем в поддержку авторов, как признанных, так и малоизвестных, претендующих на Нобелевскую премию. Такие номинации могут быть сделаны только квалифицированными номинаторами. Кто обладает правом номинировать кандидатов на Нобелевскую премию: 1. Члены Шведской академии и других академий, институтов и обществ, сходных с ней по структуре и назначению. 2. Профессора литературы и лингвистики в университетах и колледжах. 3. Предыдущие лауреаты Нобелевской премии по литературе.",
                            DateCreate = new DateTime(2023, 10, 15, 7, 54, 28, 550, DateTimeKind.Utc).AddTicks(9058),
                            PathToImage = "~/images/newsImages/4.jpg"
                        },
                        new
                        {
                            Id = 5,
                            Content = "Сегодня признанному Королю Ужасов исполняется 76 лет, и мы попросили нашего колумниста Энджи Эфенди раскрыть тайны такой притягательности прозы этого великого автора. Впервые я прочитала рассказ Кинга в девять лет в «Антологии современного американского рассказа». Никак не ожидала от смирной советской книжки, где обычно печатались истории с социальным подтекстом, и от рассказа с милым названием «Дети кукурузы» такой подставы. Потом уже стали появляться на прилавках книги Кинга в жутковатых (но креативных) обложках 90-х годов, и я узнала, насколько популярный он автор.",
                            DateCreate = new DateTime(2023, 10, 14, 7, 54, 28, 550, DateTimeKind.Utc).AddTicks(9059),
                            PathToImage = "~/images/newsImages/5.jpg"
                        });
                });

            modelBuilder.Entity("BookStore.Catalog.Entity.DepartmentEntity", b =>
                {
                    b.HasOne("BookStore.Catalog.Entity.ManagerEntity", "Manager")
                        .WithOne("Department")
                        .HasForeignKey("BookStore.Catalog.Entity.DepartmentEntity", "ManagerEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Manager");
                });

            modelBuilder.Entity("BookStore.Catalog.Entity.StoreEntity", b =>
                {
                    b.HasOne("BookStore.Catalog.Entity.BookEntity", "Book")
                        .WithMany("Stores")
                        .HasForeignKey("BookEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookStore.Catalog.Entity.DepartmentEntity", "Department")
                        .WithMany("Stores")
                        .HasForeignKey("DepartmentEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("BookStore.Catalog.Entity.BookEntity", b =>
                {
                    b.Navigation("Stores");
                });

            modelBuilder.Entity("BookStore.Catalog.Entity.DepartmentEntity", b =>
                {
                    b.Navigation("Stores");
                });

            modelBuilder.Entity("BookStore.Catalog.Entity.ManagerEntity", b =>
                {
                    b.Navigation("Department");
                });
#pragma warning restore 612, 618
        }
    }
}
