const baseUrl = 'api/UserProfile'

export const getUserByFirebaseId = (firebaseId) =>{
    return fetch(`${baseUrl}/${firebaseId}`)
        .then(res => res.json())
}