using Monsters.Data.Entities;
using Monsters.DataAccess;
using Monsters.DataAccess.EntityFramework;
using Monsters.DataAccess.Interfaces;
using Monsters.Repositories;
using Monsters.Repositories.Interfaces;
using System;

namespace _DevProject
{
    class Program
    {
        private static IUnitOfWork _unitOfWork;
        private static IUserRepository _userRepository;

        static void Main(string[] args)
        {
            Init();

            //TestAddCountry();

            //TestAddCountryUnderTransaction1();

            //TestAddCountryUnderTransaction2();


            TestGetUser();

            Console.ReadKey();
        }

        private static void Init()
        {
            MonstersDbContextInitializer.Initialize(new MonstersDbContext());

            _unitOfWork = new UnitOfWork();

            _userRepository = new UserRepository(_unitOfWork);
        }


        private static void TestGetUser()
        {
            var user1 = _userRepository.GetUser(1);
            var user2 = _userRepository.GetUser2(1);
            var user3 = _userRepository.GetUser3(1);
        }


        private static void TestAddCountry()
        {
            _userRepository.Insert(new Country
            {
                Name = Guid.NewGuid().ToString(),
                Code = Guid.NewGuid().ToString().Substring(0, 9)             
            }, 1);
            _userRepository.Savechanges();
        }

        private static void TestAddCountryUnderTransaction1()
        {
            _unitOfWork.BeginTransaction();

            _userRepository.Insert(new Country
            {
                Name = Guid.NewGuid().ToString(),
                Code = Guid.NewGuid().ToString().Substring(0, 9)
            }, 1);

            _userRepository.Savechanges();

            _unitOfWork.CommitTransaction();
        }

        private static void TestAddCountryUnderTransaction2()
        {
            _unitOfWork.BeginTransaction();

            try
            {
                _userRepository.Insert(new Country
                {
                    Name = Guid.NewGuid().ToString(),
                    Code = Guid.NewGuid().ToString().Substring(0, 9)
                }, 1);

                _userRepository.Savechanges();

                // simulate that app is crashed
                throw new Exception("Test");
                
                _unitOfWork.CommitTransaction();
            }
            catch (Exception)
            {
                _unitOfWork.RollbackTransaction();
            }
        }
    }
}
