using Planet.Domain.Boards;

namespace Planet.Persistence.Seeding
{
    public class BoardStore
    {
        public static readonly Guid[] boardIds = new Guid[]
        {
            new Guid("51012d22-9644-4e15-8e6f-7e760c099123"),
            new Guid("f05c54cf-2997-4d86-8f06-524db29edf92"),
            new Guid("e3e5c630-4bc4-4d32-8d60-9f4e139b9cfa"),
            new Guid("8937dd01-37e0-461f-8f70-28f5beb8541b"),
            new Guid("e4e7fb1e-0555-4092-b57f-ac5a0f460dfb")
        };
        public static readonly Guid[] listIds = new Guid[]
        {
            new Guid("43fa0f87-e0d2-4a06-8d0b-3d8eb2c10a8b"),
            new Guid("ad2293b1-44ad-4ab9-b0b3-c89969c9ca66"),
            new Guid("b6d52cf6-8b74-46b1-9f8a-fa85410918f1"),
            new Guid("8adad5bf-c3e1-4f64-8ed5-544326af3054"),
            new Guid("3753d6e3-0125-4bc9-906d-489f61addd4c"),
            new Guid("e7d7fdd5-72e1-4b27-a110-2b85a98b0dc0"),
            new Guid("4f7954c7-6382-40f1-8a3c-05ad85514fc7"),
            new Guid("8718bec1-742c-45cb-af3a-64e5fdb98edc"),
            new Guid("d9699c8f-0e0c-4b3c-a529-32c15cb6b081"),
            new Guid("c29707d8-8362-4299-9bc8-8120a0e79bbf"),
            new Guid("046cf4b3-f111-468f-a18e-60c2518fb1a4"),
            new Guid("13fefc6b-efc1-4619-9f42-f70be83cf8d8"),
            new Guid("53a21cf0-8742-4282-9fb6-2f549f75d02f"),
            new Guid("4abb5044-fb36-41c1-a74a-e2218fa23916"),
            new Guid("c35fbe70-00ee-4b39-be90-f1f89ccb197a")
    };
        public static readonly Guid[] labelIds = new Guid[]
        {
         new Guid("78be842c-dcb5-40c2-9d8a-c586c3e5c1e3"),
         new Guid("0d617533-191c-4dae-8431-d39bdf272a8f"),
         new Guid("63f147ab-b25b-46e6-bf58-e0a31cb39271"),
         new Guid("e11fe499-3c9a-4676-bd15-d1c646d8fca3"),
         new Guid("30a11697-9b28-45f1-a8d7-411ba94ff6de"),
         new Guid("18ff4a14-857e-451a-99e3-f0d085866056"),
         new Guid("8b9d3503-fef3-408e-8ffb-ef053844abfc"),
         new Guid("d22c1921-57e6-4ca3-b4e3-9758251a413b"),
         new Guid("3e2d5e82-acf6-43e1-87b4-6c51a9d3eefa"),
         new Guid("9656b97f-0930-4c14-ad5c-bf9ade6770cb"),
         new Guid("d5d46cb8-5bfe-41b8-bad2-efeb9aee4bf4"),
         new Guid("f0b3a6a3-3049-49cb-b292-ad818a930812"),
         new Guid("3e957e72-9855-45f4-9128-8e80520b43b9"),
         new Guid("922da183-2fe3-4bf2-aaf5-bf5150e9920d"),
         new Guid("ed446e0d-81c3-47a6-b6f6-d363fe1c1900")
    };


        private static List<BoardLabel> GetLabels()
        {
            int index = 0, page = 0;
            var labelFaker = new PrivateFaker<BoardLabel>(locale: "tr")
                .UsePrivateConstructor()
                .RuleFor(l => l.Id, f => labelIds[index++])
                .RuleFor(l => l.BoardId, f => boardIds[(page++) % boardIds.Length])
                .RuleFor(l => l.Title, f => BoardTitle.Create(f.Lorem.Sentence(3)))
                .RuleFor(l => l.Color, f => BoardLabelColor.Create(f.Random.Hexadecimal(6, string.Empty)))
                .RuleFor(l => l.IsActive, f => f.Random.Bool(0.9f));

            var labels = labelFaker.Generate(labelIds.Length);
            return labels;
        }
        private static List<BoardMember> GetMembers()
        {
            int index = 0;
            var memberFaker = new PrivateFaker<BoardMember>(locale: "tr")
                .UsePrivateConstructor()
                .RuleFor(m => m.UserId, f => UserStore.userIds[index++])
                .RuleFor(m => m.BoardId, f => boardIds[f.Random.Number(0, boardIds.Length - 1)])
                .RuleFor(m => m.Permissions, f => (BoardPermissions)f.Random.Number(0, 15))
                .RuleFor(m => m.JoinedDate, f => DateTime.Now)
                .RuleFor(m => m.IsActive, f => f.Random.Bool(0.9f));
            var members = memberFaker.Generate(UserStore.userIds.Length);
            return members;
        }
        private static List<BoardList> GetLists()
        {
            int index = 0, page = 0;
            var listFaker = new PrivateFaker<BoardList>(locale: "tr")
                .UsePrivateConstructor()
                .RuleFor(l => l.Id, f => listIds[index++])
                .RuleFor(l => l.BoardId, f => boardIds[(page++) % boardIds.Length])
                .RuleFor(l => l.Title, f => BoardTitle.Create(f.Lorem.Sentence(3)))
                .RuleFor(l => l.Order, f => f.Random.Number(0, 100));
            var lists = listFaker.Generate(listIds.Length);
            return lists;
        }

        public static List<Board> GetBoards()
        {
            int index = 0;
            var lists = GetLists();
            var members = GetMembers();
            var labels = GetLabels();
            var boardFaker = new PrivateFaker<Board>(locale: "tr")
                .UsePrivateConstructor()
                .RuleFor("_lists", f => lists.Where(l => l.BoardId == boardIds[index]).ToHashSet())
                .RuleFor("_members", f => members.Where(l => l.BoardId == boardIds[index]).ToHashSet())
                .RuleFor("_labels", f => labels.Where(l => l.BoardId == boardIds[index]).ToHashSet())
                .RuleFor(b => b.Id, f => boardIds[index++])
                .RuleFor(b => b.Title, f => BoardTitle.Create(f.Lorem.Sentence(3)))
                .RuleFor(b => b.Description, f => BoardDescription.Create(f.Lorem.Sentence(7)))
                .RuleFor(b => b.Modules, f => BoardModules.Default)
                .RuleFor(b => b.CreatedDate, f => DateTime.Now)
                .RuleFor(b => b.IsActive, f => f.Random.Bool(0.9f))
                .RuleFor(b => b.OwnerId, f => UserStore.userIds[f.Random.Int(0, UserStore.userIds.Length - 1)]);


            var boards = boardFaker.Generate(boardIds.Length);
            return boards;
        }
    }
}
