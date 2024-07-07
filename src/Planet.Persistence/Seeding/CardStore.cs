using Planet.Domain.Boards;
using Planet.Domain.Cards;

namespace Planet.Persistence.Seeding
{
    public class CardStore
    {
        private static readonly Guid[] cardIds = new Guid[]
        {
            new Guid("5a76ae90-e763-11ee-a057-c7d96c4d17af"),
            new Guid("5a76ae91-e763-11ee-a057-c7d96c4d17af"),
            new Guid("5a76ae92-e763-11ee-a057-c7d96c4d17af"),
            new Guid("5a76ae93-e763-11ee-a057-c7d96c4d17af"),
            new Guid("5a76ae94-e763-11ee-a057-c7d96c4d17af"),
            new Guid("5a76ae95-e763-11ee-a057-c7d96c4d17af"),
            new Guid("5a76ae96-e763-11ee-a057-c7d96c4d17af"),
            new Guid("5a76ae97-e763-11ee-a057-c7d96c4d17af"),
            new Guid("5a76ae98-e763-11ee-a057-c7d96c4d17af"),
            new Guid("5a76ae99-e763-11ee-a057-c7d96c4d17af"),
            new Guid("5a76ae9a-e763-11ee-a057-c7d96c4d17af"),
            new Guid("5a76ae9b-e763-11ee-a057-c7d96c4d17af"),
            new Guid("5a76ae9c-e763-11ee-a057-c7d96c4d17af"),
            new Guid("5a76ae9d-e763-11ee-a057-c7d96c4d17af"),
            new Guid("5a76ae9e-e763-11ee-a057-c7d96c4d17af"),
            new Guid("5a76ae9f-e763-11ee-a057-c7d96c4d17af"),
            new Guid("5a76aea0-e763-11ee-a057-c7d96c4d17af"),
            new Guid("5a76aea1-e763-11ee-a057-c7d96c4d17af"),
            new Guid("5a76aea2-e763-11ee-a057-c7d96c4d17af"),
            new Guid("5a76aea3-e763-11ee-a057-c7d96c4d17af"),
            new Guid("5a76aea4-e763-11ee-a057-c7d96c4d17af"),
            new Guid("5a76aea5-e763-11ee-a057-c7d96c4d17af"),
            new Guid("5a76aea6-e763-11ee-a057-c7d96c4d17af"),
            new Guid("5a76aea7-e763-11ee-a057-c7d96c4d17af"),
            new Guid("5a76aea8-e763-11ee-a057-c7d96c4d17af"),
            new Guid("5a76aea9-e763-11ee-a057-c7d96c4d17af"),
            new Guid("5a76aeaa-e763-11ee-a057-c7d96c4d17af"),
            new Guid("5a76aeab-e763-11ee-a057-c7d96c4d17af"),
            new Guid("5a76aeac-e763-11ee-a057-c7d96c4d17af"),
            new Guid("5a76aead-e763-11ee-a057-c7d96c4d17af"),
            new Guid("5a76aeae-e763-11ee-a057-c7d96c4d17af"),
            new Guid("5a76aeaf-e763-11ee-a057-c7d96c4d17af"),
            new Guid("5a76aeb0-e763-11ee-a057-c7d96c4d17af"),
            new Guid("5a76aeb1-e763-11ee-a057-c7d96c4d17af"),
            new Guid("5a76aeb2-e763-11ee-a057-c7d96c4d17af"),
            new Guid("5a76aeb3-e763-11ee-a057-c7d96c4d17af"),
            new Guid("5a76aeb4-e763-11ee-a057-c7d96c4d17af"),
            new Guid("5a76aeb5-e763-11ee-a057-c7d96c4d17af"),
            new Guid("5a76aeb6-e763-11ee-a057-c7d96c4d17af"),
            new Guid("5a76aeb7-e763-11ee-a057-c7d96c4d17af"),
            new Guid("5a76aeb8-e763-11ee-a057-c7d96c4d17af"),
            new Guid("5a76aeb9-e763-11ee-a057-c7d96c4d17af"),
            new Guid("5a76aeba-e763-11ee-a057-c7d96c4d17af"),
            new Guid("5a76aebb-e763-11ee-a057-c7d96c4d17af"),
            new Guid("5a76aebc-e763-11ee-a057-c7d96c4d17af"),
            new Guid("5a76aebd-e763-11ee-a057-c7d96c4d17af"),
            new Guid("5a76aebe-e763-11ee-a057-c7d96c4d17af"),
            new Guid("5a76aebf-e763-11ee-a057-c7d96c4d17af"),
            new Guid("5a76aec0-e763-11ee-a057-c7d96c4d17af"),
            new Guid("5a76aec1-e763-11ee-a057-c7d96c4d17af"),
            new Guid("5a76aec2-e763-11ee-a057-c7d96c4d17af"),
            new Guid("5a76aec3-e763-11ee-a057-c7d96c4d17af"),
            new Guid("5a76aec4-e763-11ee-a057-c7d96c4d17af"),
            new Guid("5a76aec5-e763-11ee-a057-c7d96c4d17af"),
            new Guid("5a76aec6-e763-11ee-a057-c7d96c4d17af"),
            new Guid("5a76aec7-e763-11ee-a057-c7d96c4d17af"),
            new Guid("5a76aec8-e763-11ee-a057-c7d96c4d17af"),
            new Guid("5a76aec9-e763-11ee-a057-c7d96c4d17af"),
            new Guid("5a76aeca-e763-11ee-a057-c7d96c4d17af"),
            new Guid("5a76aecb-e763-11ee-a057-c7d96c4d17af"),
            new Guid("5a76aecc-e763-11ee-a057-c7d96c4d17af"),
            new Guid("5a76aecd-e763-11ee-a057-c7d96c4d17af"),
            new Guid("5a76aece-e763-11ee-a057-c7d96c4d17af"),
            new Guid("5a76aecf-e763-11ee-a057-c7d96c4d17af"),
            new Guid("5a76aed0-e763-11ee-a057-c7d96c4d17af"),
            new Guid("5a76aed1-e763-11ee-a057-c7d96c4d17af"),
            new Guid("5a76aed2-e763-11ee-a057-c7d96c4d17af"),
            new Guid("5a76aed3-e763-11ee-a057-c7d96c4d17af"),
            new Guid("5a76aed4-e763-11ee-a057-c7d96c4d17af"),
            new Guid("5a76aed5-e763-11ee-a057-c7d96c4d17af"),
            new Guid("5a76aed6-e763-11ee-a057-c7d96c4d17af"),
            new Guid("5a76aed7-e763-11ee-a057-c7d96c4d17af"),
            new Guid("5a76aed8-e763-11ee-a057-c7d96c4d17af"),
            new Guid("5a76aed9-e763-11ee-a057-c7d96c4d17af"),
            new Guid("5a76aeda-e763-11ee-a057-c7d96c4d17af"),
            new Guid("5a76aedb-e763-11ee-a057-c7d96c4d17af"),
            new Guid("5a76aedc-e763-11ee-a057-c7d96c4d17af"),
            new Guid("5a76aedd-e763-11ee-a057-c7d96c4d17af"),
            new Guid("5a76aede-e763-11ee-a057-c7d96c4d17af"),
            new Guid("5a76aedf-e763-11ee-a057-c7d96c4d17af"),
            new Guid("5a76aee0-e763-11ee-a057-c7d96c4d17af"),
            new Guid("5a76aee1-e763-11ee-a057-c7d96c4d17af"),
            new Guid("5a76aee2-e763-11ee-a057-c7d96c4d17af"),
            new Guid("5a76aee3-e763-11ee-a057-c7d96c4d17af"),
            new Guid("5a76aee4-e763-11ee-a057-c7d96c4d17af"),
            new Guid("5a76aee5-e763-11ee-a057-c7d96c4d17af"),
            new Guid("5a76aee6-e763-11ee-a057-c7d96c4d17af"),
            new Guid("5a76aee7-e763-11ee-a057-c7d96c4d17af"),
            new Guid("5a76aee8-e763-11ee-a057-c7d96c4d17af"),
            new Guid("5a76aee9-e763-11ee-a057-c7d96c4d17af"),
            new Guid("5a76aeea-e763-11ee-a057-c7d96c4d17af"),
            new Guid("5a76aeeb-e763-11ee-a057-c7d96c4d17af"),
            new Guid("5a76aeec-e763-11ee-a057-c7d96c4d17af"),
            new Guid("5a76aeed-e763-11ee-a057-c7d96c4d17af"),
            new Guid("5a76aeee-e763-11ee-a057-c7d96c4d17af"),
            new Guid("5a76aeef-e763-11ee-a057-c7d96c4d17af"),
            new Guid("5a76aef0-e763-11ee-a057-c7d96c4d17af"),
            new Guid("5a76aef1-e763-11ee-a057-c7d96c4d17af"),
            new Guid("5a76aef2-e763-11ee-a057-c7d96c4d17af"),
            new Guid("5a76aef3-e763-11ee-a057-c7d96c4d17af"),
        };
        private static readonly Guid[] commentIds = new Guid[]
        {
            new Guid("2f971018-aeae-47a3-af83-42444ddc537d"),
            new Guid("c61c1d9d-5e53-4746-b428-2a7b3eb1113b"),
            new Guid("9f2904b2-c18d-4585-8a04-1def3b5c6886"),
            new Guid("56bfcb5b-8529-4f44-a354-c65ef64166f8"),
            new Guid("23776ba3-1486-48c6-8c0e-390700ae317d"),
            new Guid("c98dbbea-0219-4f40-bd4b-afd4c3ea7660"),
            new Guid("1da822b0-241f-4ff5-90a1-9293a16a2fed"),
            new Guid("75137596-7281-4d39-b245-0e6f860fa42e"),
            new Guid("adda24f1-1886-4aeb-82ef-0252bcc182ef"),
            new Guid("f0974a34-f987-4918-a980-ed039df9f621"),
            new Guid("b29f6b16-c05c-49b2-9ee7-ee21b69da7a0"),
            new Guid("46825d7b-3ada-4bbf-b53d-047fe74b99df"),
            new Guid("72c6fb26-33a1-4a0d-a3fe-94d69a54cc75"),
            new Guid("f546617d-cc1b-4553-8089-00bb467701fd"),
            new Guid("8564348f-4f76-4c7d-bbcd-93ee39c5ae94"),
            new Guid("1039b111-4f38-4b2e-b857-0b1826a96bd9"),
            new Guid("fc95d894-8370-4a4a-bb7d-9b796d70dc74"),
            new Guid("1b391bc9-16c5-4876-98ec-a89e005717ad"),
            new Guid("906db6d5-26f4-4f09-86fa-945784ae81dc"),
            new Guid("1fb9258a-6e35-4ccc-837f-9d508027ba5f"),
            new Guid("7928768b-ea0b-43d6-a5eb-7b7723e9709b"),
            new Guid("e70c416b-8c0d-4bfd-b8ce-a5af26d93678"),
            new Guid("5a1f2813-53bc-47a8-a01c-a8e6422e03ab"),
            new Guid("106fd5c2-4bb9-4cc6-9f1b-2806ae89b253"),
            new Guid("db15883a-57bf-42e8-858a-3b23d6202463"),
            new Guid("b008750d-9c3a-4084-80a1-f7e524cf7cbf"),
            new Guid("981ffa3a-8315-4c73-9cc0-e57eda30e524"),
            new Guid("ba60421a-3edd-44a7-9c4e-3804a507a13d"),
            new Guid("84714dc3-9731-465b-a53b-bd606cf28c65"),
            new Guid("bb9c08c5-3a7c-46ac-b13e-6160fee1f477"),
            new Guid("f92ec98e-326d-4c31-8f79-d11f9733e637"),
            new Guid("80a95a36-3f4c-4555-88a4-7738c15a0e16"),
            new Guid("6834d3b0-a628-4d98-afaa-ee569d7838f1"),
            new Guid("982ca470-3bec-4382-bbc7-16fec6b43b77"),
            new Guid("d56a06d9-954a-4f46-8e48-15c186ccc8b0"),
            new Guid("a43931b7-3a9b-418c-a2b3-239b9a5b01dc"),
            new Guid("193554e1-18ac-4b7f-b7ee-cf976e99c8ed"),
            new Guid("bd449023-86cb-4f55-bd4b-c83a517e4f06"),
            new Guid("8eb56027-894b-4fe9-a005-f0a162148b96"),
            new Guid("96029bfb-e4ad-4cc7-af42-ac1a1f442ea0"),
            new Guid("e1eb8efc-5075-47e0-aab7-b59344ca4dc0"),
            new Guid("f87b2202-8a10-45a5-b6ae-799ee0aed841"),
            new Guid("44f3c452-c774-4672-acbd-069714b0f4ae"),
            new Guid("d1243435-fc75-4ad1-813e-e975426c114d"),
            new Guid("34e6249f-dd6e-4405-aae1-df0cc62196b0"),
            new Guid("6687660f-4dcf-4cd6-9e69-cf4674664f22"),
            new Guid("4ac560b6-0e68-45fa-9f90-6ec44d29a053"),
            new Guid("984b2c52-03d6-405a-9b5a-79d2fdadaaed"),
            new Guid("42c091b7-7740-41b3-8ecc-bb86f73c14da"),
            new Guid("bb4d315b-98e9-4aed-a633-a001f2a8e0a9"),
            new Guid("465bab86-50d3-4d00-ac6a-92d1fbf9df3e"),
            new Guid("aa824008-86e4-41b3-ae91-09fa6a999dad"),
            new Guid("54b2e419-6413-4af6-9b2c-5a2195061b7e"),
            new Guid("00c0a3ab-4846-4b1c-90f1-f5b7d4ee1ced"),
            new Guid("96b26fd8-f11e-41dc-a452-f2266aeda543"),
            new Guid("79eda275-c108-4552-92ac-deb2d5a2447b"),
            new Guid("5e11ead4-3346-4a21-a40e-0b322fa6414a"),
            new Guid("69635bb4-45fa-4fe0-a62d-77b68f348379"),
            new Guid("52607469-40cf-4981-a190-e09e1ff50a25"),
            new Guid("538897ec-168a-4eba-9c5d-99d42a246ec7"),
            new Guid("cfe0d281-d5d2-4141-8a87-b6a95b22c9f9"),
            new Guid("bb2c63ba-f2b0-4eee-873b-5f616513b823"),
            new Guid("87fdf643-43d3-4c02-882e-3564a081ce92"),
            new Guid("0d1baf99-9673-4a19-a06d-fc65a7e00876"),
            new Guid("72d34fcf-9331-444f-946e-37dc48722401"),
            new Guid("56b762c0-6af1-4761-928d-0436f4fa6eec"),
            new Guid("ae5e0caf-2bea-48d7-b024-2f5f3ecef854"),
            new Guid("43b25798-26da-457d-a899-1e3d183696b2"),
            new Guid("e607838e-dc03-4454-a948-6a17e7f8d338"),
            new Guid("2272da2f-c0dd-40e3-bc84-21c616f8064b"),
            new Guid("e4a01509-d8f9-49be-af11-b65a6399999a"),
            new Guid("d0fae6ce-e4af-4c6f-9a96-e838a8ecd8f2"),
            new Guid("269759d0-d6d1-4253-9161-93463c1c6909"),
            new Guid("178c23d4-b736-4b81-9eaf-ea513683bcd0"),
            new Guid("3572efc2-c46f-4848-8f8b-dea31db512b1"),
            new Guid("fd878ed0-d72b-424a-b5e6-dd5d934edc9c"),
            new Guid("66e5ac51-13ee-4f26-b73b-e5deff118f0b"),
            new Guid("53bded81-3593-4d0a-a4da-4e2f66821e40"),
            new Guid("ec540d38-9228-4ed3-8e5d-88cb7671ed98"),
            new Guid("0b871981-50b3-4d31-b66f-4f94e048bf33"),
            new Guid("bf1dfc65-c7ea-42a4-aa33-e57d12007bca"),
            new Guid("534d2dd8-b6ff-4fd2-8581-5c39d233d621"),
            new Guid("0539a85b-46ee-4e3e-846e-d911f5a3c0fa"),
            new Guid("980a12d9-b475-4a94-8dbc-48d868b40634"),
            new Guid("95a92a29-2b73-4362-abb6-28091d734c1e"),
            new Guid("160381b9-a2d8-4157-a142-b9d97646e49a"),
            new Guid("dbb376e3-ce43-493a-9899-4577e3875312"),
            new Guid("74f8219b-1f5f-4d1d-bb7c-bfc7ac924120"),
            new Guid("6669cbd9-b5e0-4a56-bff2-77a884ebfc1e"),
            new Guid("91e86997-790e-4edd-9a24-dc51775aad03"),
            new Guid("57f990ec-47c2-42b9-a5da-f4df5639316d"),
            new Guid("3c9a5fc6-92d4-445b-95ee-af32c916759b"),
            new Guid("a83a7dcd-5b06-4aa9-98a8-684b6c5eccfe"),
            new Guid("a250ffd0-df84-4017-95df-cfcb7e0e8ace"),
            new Guid("5c556bae-662a-43e1-9606-231f027fb0e4"),
            new Guid("22f916bf-2f47-41db-8ea0-62872947349e"),
            new Guid("03783be8-9213-4813-8a58-ffad7774df6e"),
            new Guid("70926966-a26a-4644-9f26-a6c51d7f23c5"),
            new Guid("73a71931-6e1b-4b2d-99c6-75acfc7495fc"),
            new Guid("9564f72b-9696-4aa7-8f9f-ffe9dd5e6271"),
            new Guid("d91dfbc4-04c7-4f6c-974c-33be98e7092d"),
            new Guid("1ac940da-701b-47e1-b235-38f955076e23"),
            new Guid("ad6593ee-c626-4fd4-bc6a-4f1aeff80aac"),
            new Guid("89b138e7-6286-4a90-8797-ea3044558be0"),
            new Guid("bfe990f5-eb35-4236-966d-a84fd2c299b0"),
            new Guid("4040b537-15a6-4b3d-a424-40c6e5da3ba3"),
            new Guid("41a5e243-c4c0-4cf0-9227-1df93cf157fc"),
            new Guid("549836b0-4302-47c2-b330-5bff9ed7d318"),
            new Guid("066e18cb-11b6-4f98-bc1c-fb14032c9f84"),
            new Guid("3a4527d0-d2f3-4196-8643-f7a7dfeea30e"),
            new Guid("6dae9b6f-3692-4cf0-bf59-2cb82c295c21"),
            new Guid("60888f40-0bb3-4492-81dd-1edc887186ce"),
            new Guid("f18018a2-a2b1-4605-abdb-4928eb216104"),
            new Guid("b7596270-61b2-4a0d-959f-8b7c8ee4cd0f"),
            new Guid("257101ac-f11a-40b4-8441-1d7401a3da6a"),
            new Guid("1b4635f3-ef1a-4275-9aab-22b7fcf86b89"),
            new Guid("2d2b0f23-e594-4d8b-93ce-44990f8c9586"),
            new Guid("57bb8be6-0a88-459c-a5d0-ce1b606b5a5e"),
            new Guid("ec97ae12-73dc-46c9-a4ff-e55d3dba08ac"),
            new Guid("f72ade16-b629-4c7b-92f2-34440135ae47"),
            new Guid("40b5ca10-71bb-459e-892b-310f5a2f293b"),
            new Guid("3ca42548-1d30-40b8-8a62-ce830a82397c"),
            new Guid("b116e7a6-59a6-4ab7-8103-767c3f8e02b6"),
            new Guid("ba2e9300-1aa7-42bf-aa45-d4f584f4e759"),
            new Guid("38d386d7-621c-4fe6-833a-68e5add571d4"),
            new Guid("78e50bc4-eca6-459d-aa4f-beb12639d525"),
            new Guid("5a63c769-7d5f-4013-8d97-dc96709c903d"),
            new Guid("d694badd-830b-48f7-a422-a4120c493fcf"),
            new Guid("786fdc4d-198a-44f0-ab26-ba1ded801dfb"),
            new Guid("bbe228e4-2f5c-4efa-8d18-91691698423e"),
            new Guid("64563c4e-7f1d-4a30-92fa-8a532f3ee718"),
            new Guid("77909b11-afa3-4da5-bd43-45dee0a5b7a4"),
            new Guid("28f87c99-2e59-44e3-badc-ac8fd6d0e38d"),
            new Guid("99f54ddf-9d67-4ca3-a87a-49d54d958a20"),
            new Guid("3e558bcb-b66f-4b94-9202-08a46eb8cae1"),
            new Guid("dd49cac5-2927-453b-8e8a-9af38ad71145"),
            new Guid("7730ed8c-b247-475f-8181-05c0ee825cc5"),
            new Guid("b7502daf-f070-4cc4-8b42-3ae87f417441"),
            new Guid("ccb851c5-1e4a-490b-bb91-e4a97cf1c3de"),
            new Guid("15bc12c1-b9c4-4370-88b4-83eac1bb443f"),
            new Guid("883acf37-cba7-43eb-87ea-485d1a0e80ca"),
            new Guid("a132436b-44e4-4a2f-a7d4-f546865d5689"),
            new Guid("3b99608e-476d-4762-bb7f-c5bbde44f6b4"),
            new Guid("040c2cd2-a631-43c8-a188-4bf12ca97098"),
            new Guid("202f2274-21f9-4559-a0cb-260332b6f2f6"),
            new Guid("b166d6ed-9aae-4eeb-8d3f-17f4689faef7"),
            new Guid("43ad82d1-8ac8-4bcf-8ad0-1035e51333a6"),
            new Guid("c756fdaa-2ef6-4911-ad87-89c99fe950fb"),
            new Guid("9c994f96-7f56-4722-8fad-db54025d9d9f"),
            new Guid("f012d0da-770e-4d5d-b74c-65e7c60e9aa6"),
            new Guid("6a234d08-3a66-45fc-bc7d-d1a541200682"),
            new Guid("7bb051f8-bb94-4d18-8f87-7118339cdd1a"),
            new Guid("484d3f79-cf1c-4db4-b13e-ccf00e791de9"),
            new Guid("f91e84c2-bc27-480b-abb7-880b88879cac"),
            new Guid("e421ed57-bc6a-42da-b600-81e85b49d95e"),
            new Guid("86657d8c-c570-4218-a016-044534af34fc"),
            new Guid("5ede8fc4-673a-4be6-a4e1-a7f08b15e061"),
            new Guid("d6f42111-3391-4af3-b470-181e464f46da"),
            new Guid("421a029d-f3c6-40c6-a5ca-b06f96475a01"),
            new Guid("a63f8211-c89c-4def-ae71-4723a7d50f0b"),
            new Guid("aa32f6c8-40ee-46e5-b679-2bc3cff36170"),
            new Guid("8df59027-85d5-4cdd-b8aa-1fe1052b45f1"),
            new Guid("a133797d-5896-424f-a882-af36d2e90139"),
            new Guid("638cf066-1159-44b3-95a7-4bfd0ea68cd9"),
            new Guid("8ff65756-d536-46ca-bcd9-c9e6d615d682"),
            new Guid("38cdd6bf-f6a2-44f5-90ad-f7fa6b39fc67"),
            new Guid("e64c67d3-155e-4ac3-b847-b8ce1abdcceb"),
            new Guid("5eb8f695-8c95-4d1d-a229-b2503bbac538"),
            new Guid("a7f68482-bb15-431c-973d-2093a393dd4a"),
            new Guid("d7680447-4d9a-45e8-97cf-c9efe7cb1a17"),
            new Guid("2e1ede08-4832-443e-945a-731059b0ee0b"),
            new Guid("b62ddd2b-e9ba-4db8-97c1-9a1ed4d5a696"),
            new Guid("861c401b-fd9f-4006-a43b-2b91c7f72153"),
            new Guid("4d4529cb-55d4-4323-ba36-2668f8a71b3f"),
            new Guid("98f13153-b3c4-4f98-b9b2-6668a8582fda"),
            new Guid("b07e82a0-a71b-432a-9d0a-2c2eab701329"),
            new Guid("5965ac93-cd21-4761-bd57-47f1601c9d46"),
            new Guid("594e6be9-4e16-4047-8aa2-c0187e697350"),
            new Guid("2feacce2-db93-4aed-933a-49efafec497d"),
            new Guid("bee3723e-aa89-4796-aede-dd815d8be30a"),
            new Guid("d6f3ab78-1060-4ca4-b8ac-6fffd5e35e0c"),
            new Guid("bf1a451e-69d4-400f-8337-a16f32ee8807"),
            new Guid("dcb17a87-b1fa-4912-bd0d-7db22ed0e947"),
            new Guid("ba284b36-9a0c-4ea1-a670-91cdfe79816b"),
            new Guid("b2aceca9-d347-4e21-9d0e-c7305fa2482d"),
            new Guid("1fabd653-86af-402b-9ac9-a0cb212602e1"),
            new Guid("d8d32c52-3e58-40ff-918c-b6b9164c5a9c"),
            new Guid("05e3f408-c1e5-47b3-943b-b801825852e0"),
            new Guid("b3453465-fe81-4672-a164-58593704cf60"),
            new Guid("a313c148-9bea-4e19-9c3b-7b9837b2e439"),
            new Guid("59ab5621-4548-429f-a0f3-231ed85b834d"),
            new Guid("5b164c19-6161-459b-a3a2-a079e864f599"),
            new Guid("ea87d142-3497-43c7-af38-aba98559f202"),
            new Guid("e5843e7d-fd03-4bc5-b82e-7d9cdd70f1ef"),
            new Guid("01f7505a-8f6d-4a5c-81b5-61d719993035"),
            new Guid("36a7c5e9-461a-4c8b-8acb-91cb6b97ec77"),
            new Guid("214de345-3131-4bd8-8791-3ffb27149ab5"),
            new Guid("fbecc478-81a4-411f-a2d7-b22d0fc4e0f2"),
            new Guid("aba3738b-77c2-4b57-9533-dba44ca0de5c"),
            new Guid("be8ec65c-03e0-46d1-be61-5796607e1ac9"),
            new Guid("430d1e01-a208-4d47-a306-05f236fdb229"),
            new Guid("24e5f83e-d766-42b4-bbec-5d7b35fa8d51"),
            new Guid("6e7de5f3-3ead-4d68-a2a9-19f001b602a0"),
            new Guid("c57f1fd9-4af8-4690-b5de-e2a6fe370c99"),
            new Guid("3d4bc748-ae4d-4bbe-8cba-75df1a1543b3"),
            new Guid("78f29681-ca0c-4142-9d80-1ef5306fc1c4"),
            new Guid("08cfb9c4-3d07-46cd-bad5-b6701eda6f55"),
            new Guid("9fb6e71b-d9e3-4a12-a91d-ad0cfd0c02e1"),
            new Guid("1f0d9f0d-3df4-4325-b091-161368aa6012"),
            new Guid("bf1d9ae5-ba26-44ef-9286-dcf8fd6705a8"),
            new Guid("b840215e-3dd6-4c44-b561-cd9c6bbf2669"),
            new Guid("8df69391-81d5-47c8-bc51-f0e9b2c04b37"),
            new Guid("eb449836-75d1-45bf-9dbf-68bbc7613be8"),
            new Guid("ae4732fe-d6e2-417f-8987-355ca26310ca"),
            new Guid("0aecf1ab-0e9f-4bd3-aca1-b87d62881bad"),
            new Guid("582866c5-da73-4bf9-80d7-ba66a39875cd"),
            new Guid("8cdd86fb-d1ab-4f33-a704-84d0127834db"),
            new Guid("af1f55f4-a855-4611-8bde-4676dc659b7d"),
            new Guid("6eb89aec-dadf-4a81-9198-e5f8470e38bf"),
            new Guid("601f2bbd-e8f9-4b9a-9047-dfd25d9f2852"),
            new Guid("01948288-5843-4613-a63e-60a4327aadc4"),
            new Guid("8637ee71-fe82-4331-afac-dbd67fedb375"),
            new Guid("e494563c-9459-4253-a0cd-332cfd00b556"),
            new Guid("e65b7269-24a0-45d1-aa8c-2f2ad901c61e"),
            new Guid("37174af9-1966-4f29-a98a-d1d421b85996"),
            new Guid("86d12bd3-7489-45dc-bbad-6a470d18185c"),
            new Guid("2434c48c-cd34-49f0-b711-7af40fe9a6ef"),
            new Guid("65fc8575-982d-4cd5-a3b8-608a9e706a74"),
            new Guid("e27aa2db-13e0-4374-90b7-9cd92678702d"),
            new Guid("d7710145-c162-4ce7-ab94-120b174d4672"),
            new Guid("c6fd7acf-a0b6-4ce4-b281-b8e73ce1a015"),
            new Guid("826a533c-4886-4430-9103-72ed93f2cfa5"),
            new Guid("068b8419-b0ce-460a-a651-6a8e8698fddf"),
            new Guid("70079c66-8723-48f8-89d2-adb77f777905"),
            new Guid("def39756-856b-4603-8fb5-f6aa1adb1172"),
            new Guid("deb9b3e5-c93a-4210-8e2e-1f087a065710"),
            new Guid("e4d866d6-a72d-46d0-aa0d-9a5bf7eeb568"),
            new Guid("335145d6-6715-400a-b1d9-f5e7975cbf7d"),
            new Guid("29d10bed-eee6-4e5f-9353-4a6b0217a256"),
            new Guid("fc9c1bf8-0f84-4219-a117-c43a7611f936"),
            new Guid("cda01249-2c7b-4ee6-aa4b-b14f1ad25857"),
            new Guid("289d7cff-4e73-4f89-b70a-d8ab6be7c719"),
            new Guid("6ba040e1-631b-48eb-a96e-b555eaee3385"),
            new Guid("c9c12be0-32bc-431f-b504-6bf0684b8b03"),
            new Guid("0fb52116-273e-43ef-9468-dd2211a05b74"),
            new Guid("3b06a7a2-a46e-4ce3-bd8a-7bdf89226928"),
            new Guid("7a96b8c0-e75e-4fb6-b463-401dd18b12fe"),
            new Guid("8c672180-c38e-4211-93a8-2f72b3b8ad08"),
            new Guid("8204a39b-7f4c-4b34-8ec5-5f8b62270597"),
            new Guid("906a376e-9f7d-45f1-a2c6-7bea21c3df13")
        };
        private static readonly Guid[] checkListIds = new Guid[]
        {
            new Guid("e8c8cf84-e9de-11ee-976b-35cf0f185f86"),
            new Guid("e8c8cf85-e9de-11ee-976b-35cf0f185f86"),
            new Guid("e8c8cf86-e9de-11ee-976b-35cf0f185f86"),
            new Guid("e8c8cf87-e9de-11ee-976b-35cf0f185f86"),
            new Guid("e8c8cf88-e9de-11ee-976b-35cf0f185f86"),
            new Guid("e8c8cf89-e9de-11ee-976b-35cf0f185f86"),
            new Guid("e8c8cf8a-e9de-11ee-976b-35cf0f185f86"),
            new Guid("e8c8cf8b-e9de-11ee-976b-35cf0f185f86"),
            new Guid("e8c8cf8c-e9de-11ee-976b-35cf0f185f86"),
            new Guid("e8c8cf8d-e9de-11ee-976b-35cf0f185f86"),
            new Guid("e8c8cf8e-e9de-11ee-976b-35cf0f185f86"),
            new Guid("e8c8cf8f-e9de-11ee-976b-35cf0f185f86"),
            new Guid("e8c8cf90-e9de-11ee-976b-35cf0f185f86"),
            new Guid("e8c8cf91-e9de-11ee-976b-35cf0f185f86"),
            new Guid("e8c8cf92-e9de-11ee-976b-35cf0f185f86"),
            new Guid("e8c8cf93-e9de-11ee-976b-35cf0f185f86"),
            new Guid("e8c8cf94-e9de-11ee-976b-35cf0f185f86"),
            new Guid("e8c8cf95-e9de-11ee-976b-35cf0f185f86"),
            new Guid("e8c8cf96-e9de-11ee-976b-35cf0f185f86"),
            new Guid("e8c8cf97-e9de-11ee-976b-35cf0f185f86"),
            new Guid("e8c8cf98-e9de-11ee-976b-35cf0f185f86")
        };
        private static readonly Guid[] checkListItemIds = new Guid[]
        {
         new Guid("f2421ff0-e9e0-11ee-976b-35cf0f185f86"),
         new Guid("f2421ff1-e9e0-11ee-976b-35cf0f185f86"),
         new Guid("f2421ff2-e9e0-11ee-976b-35cf0f185f86"),
         new Guid("f2421ff3-e9e0-11ee-976b-35cf0f185f86"),
         new Guid("f2421ff4-e9e0-11ee-976b-35cf0f185f86"),
         new Guid("f2421ff5-e9e0-11ee-976b-35cf0f185f86"),
         new Guid("f2421ff6-e9e0-11ee-976b-35cf0f185f86"),
         new Guid("f2421ff7-e9e0-11ee-976b-35cf0f185f86"),
         new Guid("f2421ff8-e9e0-11ee-976b-35cf0f185f86"),
         new Guid("f2421ff9-e9e0-11ee-976b-35cf0f185f86"),
         new Guid("f2421ffa-e9e0-11ee-976b-35cf0f185f86"),
         new Guid("f2421ffb-e9e0-11ee-976b-35cf0f185f86"),
         new Guid("f2421ffc-e9e0-11ee-976b-35cf0f185f86"),
         new Guid("f2421ffd-e9e0-11ee-976b-35cf0f185f86"),
         new Guid("f2421ffe-e9e0-11ee-976b-35cf0f185f86"),
         new Guid("f2421fff-e9e0-11ee-976b-35cf0f185f86"),
         new Guid("f2422000-e9e0-11ee-976b-35cf0f185f86"),
         new Guid("f2422001-e9e0-11ee-976b-35cf0f185f86"),
         new Guid("f2422002-e9e0-11ee-976b-35cf0f185f86"),
         new Guid("f2422003-e9e0-11ee-976b-35cf0f185f86")
    };


        public static List<Card> GetCards(List<IGrouping<Guid, BoardMember>> memberGroups, List<IGrouping<Guid, BoardList>> listGroups, List<IGrouping<Guid, BoardLabel>> labelGroups)
        {
            int index = 0;
            Guid boardId = Guid.Empty;

            var cardFaker = new PrivateFaker<Card>(locale: "tr")
                .UsePrivateConstructor()
                .RuleFor(c => c.Id, f => cardIds[index++])
                .RuleFor(c => c.Title, f => CardTitle.Create(f.Lorem.Sentence(3)))
                .RuleFor(c => c.Description, f => CardDescription.Create(f.Lorem.Sentence(5)))
                .RuleFor(c => c.ListId, f =>
                {
                    var listGroup = listGroups[f.Random.Number(0, listGroups.Count - 1)];
                    boardId = listGroup.Key;
                    return listGroup.ToList()[f.Random.Number(0, listGroup.Count() - 1)].Id;
                })
                .RuleFor(c => c.OwnerId, (f, c) =>
                {
                    var listGroup = listGroups.FirstOrDefault(g => g.Any(l => l.Id == c.ListId));
                    var memberGroup = memberGroups.FirstOrDefault(g => g.Key == listGroup.First().BoardId);
                    return memberGroup.ToList()[f.Random.Number(0, memberGroup.Count() - 1)].UserId;
                })
                .RuleFor(c => c.CreatedDate, f => DateTime.Now)
                .RuleFor(c => c.AssignedToId, (f, c) =>
                {
                    var listGroup = listGroups.FirstOrDefault(g => g.Any(l => l.Id == c.ListId));
                    var memberGroup = memberGroups.FirstOrDefault(g => g.Key == listGroup.First().BoardId).ToList();
                    var memberId = memberGroup[f.Random.Number(0, memberGroup.Count - 1)].UserId;
                    return f.Random.Bool(0.75f) ? memberId : null;
                })
                .RuleFor(c => c.Order, f => f.Random.Double() * Math.Pow(2, 10))
                .RuleFor(c => c.IsDeleted, f => f.Random.Bool(0.05f))
                .RuleFor("_labels", (f, c) =>
                {
                    var boardId = listGroups.FirstOrDefault(g => g.Any(l => l.Id == c.ListId)).First().BoardId;
                    var labels = labelGroups.FirstOrDefault(g => g.Key == boardId).ToList();

                    return GetLabels(c.Id, labels);
                })
                .RuleFor("_comments", (f, c) =>
                {
                    var boardId = listGroups.FirstOrDefault(g => g.Any(l => l.Id == c.ListId)).First().BoardId;
                    var members = memberGroups.FirstOrDefault(g => g.Any(m => m.BoardId == boardId)).ToList();

                    return GetComments(c.Id, members);
                })
                .RuleFor("_checkLists", (f, c) => GetCheckLists(c.Id));

            var cards = cardFaker.Generate(cardIds.Length);

            return cards;


        }

        public static List<CardComment> GetComments(Guid cardId, List<BoardMember> members)
        {
            int count = new Random().Next(1, 10);
            var commentFaker = new PrivateFaker<CardComment>(locale: "tr")
                .UsePrivateConstructor()
                .RuleFor(c => c.Id, f => f.Random.Guid())
                .RuleFor(c => c.CardId, f => cardId)
                .RuleFor(c => c.UserId, f => f.Random.CollectionItem(members).UserId)
                .RuleFor(c => c.Content, f => CardCommentContent.Create(f.Lorem.Sentence(5)));

            var comments = commentFaker.Generate(count);

            return comments;
        }

        public static List<CardCheckList> GetCheckLists(Guid cardId)
        {
            int count = new Random().Next(0, 5);
            var checkListFaker = new PrivateFaker<CardCheckList>(locale: "tr")
                .UsePrivateConstructor()
                .RuleFor(c => c.Id, f => f.Random.Guid())
                .RuleFor(c => c.CardId, f => cardId)
                .RuleFor(c => c.CardTitle, f => CardTitle.Create(f.Lorem.Sentence(3)))
                .RuleFor("_items", (f, c) => GetCheckListItems(c.Id));

            var checkLists = checkListFaker.Generate(count);

            return checkLists;
        }

        public static List<CardCheckListItem> GetCheckListItems(Guid checkListId)
        {
            int count = new Random().Next(2, 8);
            var checkListItemFaker = new PrivateFaker<CardCheckListItem>(locale: "tr")
                .UsePrivateConstructor()
                .RuleFor(c => c.Id, f => f.Random.Guid())
                .RuleFor(c => c.CheckListId, f => checkListId)
                .RuleFor(c => c.Content, f => CardCheckListItemContent.Create(f.Lorem.Sentence(3)))
                .RuleFor(c => c.IsChecked, f => f.Random.Bool(0.5f));

            var checkListItems = checkListItemFaker.Generate(count);

            return checkListItems;
        }

        private static List<CardLabel> GetLabels(Guid cardId, List<BoardLabel> labels)
        {
            int index = 0;
            int count = new Random().Next(0, labels.Count);
            var labelFaker = new PrivateFaker<CardLabel>(locale: "tr")
                .UsePrivateConstructor()
                .RuleFor(l => l.CardId, f => cardId)
                .RuleFor(l => l.BoardLabelId, f => labels[index++].Id);

            var cardLabels = labelFaker.Generate(count);

            return cardLabels;
        }

    }
}
