using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookStore.EF.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    PathToImage = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<double>(type: "double precision", nullable: false),
                    PageCount = table.Column<int>(type: "integer", nullable: false),
                    Genre = table.Column<byte>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Managers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Mail = table.Column<string>(type: "text", nullable: true),
                    Number = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Managers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DateCreate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PathToImage = table.Column<string>(type: "text", nullable: true),
                    Content = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Login = table.Column<string>(type: "text", nullable: true),
                    Password = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Role = table.Column<byte>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Address = table.Column<string>(type: "text", nullable: true),
                    ManagerEntityId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Departments_Managers_ManagerEntityId",
                        column: x => x.ManagerEntityId,
                        principalTable: "Managers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    DepartmentEntityId = table.Column<int>(type: "integer", nullable: false),
                    BookEntityId = table.Column<int>(type: "integer", nullable: false),
                    BookCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => new { x.DepartmentEntityId, x.BookEntityId });
                    table.ForeignKey(
                        name: "FK_Stores_Books_BookEntityId",
                        column: x => x.BookEntityId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Stores_Departments_DepartmentEntityId",
                        column: x => x.DepartmentEntityId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Genre", "Name", "PageCount", "PathToImage", "Price" },
                values: new object[,]
                {
                    { 1, (byte)2, "Граф Аверин. Колдун Российской империи", 320, "/images/catalogImages/1.jpg", 550.0 },
                    { 2, (byte)4, "Портрет Дориана Грея", 480, "/images/catalogImages/2.jpg", 690.0 },
                    { 3, (byte)1, "Ваш покорный слуга кот", 120, "/images/catalogImages/3.jpg", 480.0 },
                    { 4, (byte)1, "1984 (новый перевод)", 370, "/images/catalogImages/4.jpg", 550.0 },
                    { 5, (byte)2, "Триумфальная арка", 390, "/images/catalogImages/9.jpg", 440.0 },
                    { 6, (byte)2, "На Западном фронте без перемен", 280, "/images/catalogImages/5.jpg", 500.0 },
                    { 7, (byte)1, "Грозовой перевал", 410, "/images/catalogImages/6.jpg", 380.0 },
                    { 8, (byte)2, "Клуб самоубийц", 410, "/images/catalogImages/7.jpg", 570.0 },
                    { 9, (byte)4, "Мартин Иден", 380, "/images/catalogImages/8.jpg", 410.0 },
                    { 10, (byte)4, "Маленький принц", 230, "/images/catalogImages/10.jpg", 600.0 },
                    { 11, (byte)5, "Отцы и дети", 510, "/images/catalogImages/11.jpg", 380.0 },
                    { 12, (byte)3, "Работа легкой не бывает", 300, "/images/catalogImages/12.jpg", 750.0 }
                });

            migrationBuilder.InsertData(
                table: "Managers",
                columns: new[] { "Id", "Mail", "Name", "Number" },
                values: new object[,]
                {
                    { 1, "khabfafkjhb@gmail.com", "Валиев Антон Дмитриевич", "898249553535" },
                    { 2, "akjbfkabfjhabf@gmail.com", "Полынский Арсений Андреевич", "898005553536" },
                    { 3, "1894bafbahfbj@gmail.com", "Рогожников Даниил Владимирович", "898005553535" }
                });

            migrationBuilder.InsertData(
                table: "News",
                columns: new[] { "Id", "Content", "DateCreate", "PathToImage" },
                values: new object[,]
                {
                    { 1, "Сентябрь 2023. Выпуск №3 Это интересно 1. Литературный тиндер: любовь в советскую и постсоветскую эпохи. Мы пофантазировали о том, как выглядели бы профили персонажей советских и современных российских писателей в дейтингах, и как сложились бы их отношения, если они нашли бы друг друга именно там. 2. Что мир читал в 1865 году? Пришествие Алисы и полет на Луну. В этом году читателю выпало свести знакомство с целым рядом очень интересных книг самого разного жанра. И с целым рядом авторов, о которых он раньше и не слышал. 3. Почему из «Смертельного образования» получилось бы классное аниме. Смертельно опасная школа волшебников, подростки", new DateTime(2023, 10, 18, 8, 29, 51, 229, DateTimeKind.Utc).AddTicks(7320), "/images/newsImages/1.jpg" },
                    { 2, "В день рождения великого языковеда Сергея Ивановича Ожегова, составителя одного из самых популярных толковых словарей, мы с вами ненадолго перенесемся в прошлое и проверим знание старинных или вышедших из употребления слов. Пройти тест", new DateTime(2023, 10, 17, 8, 29, 51, 229, DateTimeKind.Utc).AddTicks(7327), "/images/newsImages/2.jpg" },
                    { 3, "В современном мире множество причин для тревог: нелюбимая работа, вынужденный переезд, утрата  близких... Неисчерпаемый колодезь личных проблем — неспособность принять себя, синдром самозванца, страх совершить ошибку и многое, многое другое. Новая книга психолога Ольги Примаченко, автора бестселлера «К себе нежно», послужит лекарством для ран и тревог. Конечно, нет универсального рецепта для всех на свете проблем, зато можно научиться верить себе, спокойно воспринимать окружающий мир и строить жизнь так, как хочется нам, а не так, как диктуют другие. Ольга Примаченко - Всё закончится, а ты нет. ", new DateTime(2023, 10, 16, 8, 29, 51, 229, DateTimeKind.Utc).AddTicks(7328), "/images/newsImages/3.jpg" },
                    { 4, "С прошлого ноября, как и каждый предыдущий год, Шведская академия получает тысячи писем в поддержку авторов, как признанных, так и малоизвестных, претендующих на Нобелевскую премию. Такие номинации могут быть сделаны только квалифицированными номинаторами. Кто обладает правом номинировать кандидатов на Нобелевскую премию: 1. Члены Шведской академии и других академий, институтов и обществ, сходных с ней по структуре и назначению. 2. Профессора литературы и лингвистики в университетах и колледжах. 3. Предыдущие лауреаты Нобелевской премии по литературе.", new DateTime(2023, 10, 15, 8, 29, 51, 229, DateTimeKind.Utc).AddTicks(7329), "/images/newsImages/4.jpg" },
                    { 5, "Сегодня признанному Королю Ужасов исполняется 76 лет, и мы попросили нашего колумниста Энджи Эфенди раскрыть тайны такой притягательности прозы этого великого автора. Впервые я прочитала рассказ Кинга в девять лет в «Антологии современного американского рассказа». Никак не ожидала от смирной советской книжки, где обычно печатались истории с социальным подтекстом, и от рассказа с милым названием «Дети кукурузы» такой подставы. Потом уже стали появляться на прилавках книги Кинга в жутковатых (но креативных) обложках 90-х годов, и я узнала, насколько популярный он автор.", new DateTime(2023, 10, 14, 8, 29, 51, 229, DateTimeKind.Utc).AddTicks(7330), "/images/newsImages/5.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Login", "Name", "Password", "Role" },
                values: new object[,]
                {
                    { 1, "user1", "User1", "user1", (byte)2 },
                    { 2, "user2", "User2", "user2", (byte)2 },
                    { 3, "user3", "User3", "user3", (byte)2 },
                    { 4, "admin1", "Admin1", "admin1", (byte)1 }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Address", "ManagerEntityId" },
                values: new object[,]
                {
                    { 1, "Цемлянская, 23", 1 },
                    { 2, "Братская, 77", 2 },
                    { 3, "Ленина, 12", 3 }
                });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "BookEntityId", "DepartmentEntityId", "BookCount" },
                values: new object[,]
                {
                    { 1, 1, 50 },
                    { 4, 1, 18 },
                    { 7, 1, 57 },
                    { 10, 1, 14 },
                    { 2, 2, 30 },
                    { 5, 2, 99 },
                    { 8, 2, 58 },
                    { 11, 2, 15 },
                    { 3, 3, 27 },
                    { 6, 3, 56 },
                    { 9, 3, 12 },
                    { 12, 3, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Departments_ManagerEntityId",
                table: "Departments",
                column: "ManagerEntityId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Stores_BookEntityId",
                table: "Stores",
                column: "BookEntityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropTable(
                name: "Stores");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Managers");
        }
    }
}
