const driveUrl = "api/Drive"
const fragmentUrl = "api/DriveFragment"

export const getDriveFragment = () =>{
    return fetch(fragmentUrl).then(res => res.json())
}

export const getDrive = () =>{
    return fetch(driveUrl).then(res => res.json())
}