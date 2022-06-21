using GeorgesRecipeRoomFullStack.Models;
using System.Collections.Generic;

namespace GeorgesRecipeRoomFullStack.Repositories
{
    public interface IUserProfileRepository
    {
        UserProfile GetByFirebaseUserId(string firebaseUserId);       
        void Add(UserProfile userProfile);
        
    }
}