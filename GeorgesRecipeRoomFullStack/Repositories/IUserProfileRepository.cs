using GeorgesRecipeRoomFullStack.Models;
using System.Collections.Generic;

namespace GeorgesRecipeRoomFullStack.Repositories
{
    public interface IUserProfileRepository
    {
        void Add(UserProfile userProfile);
        UserProfile GetByFirebaseUserId(string firebaseUserId);
        //List<UserProfile> GetAll();
        //UserProfile GetById(int id);
        //void Delete(int id);
        UserProfile GetUser(string userName);
        //void Update(UserProfile userProfile);
    }
}