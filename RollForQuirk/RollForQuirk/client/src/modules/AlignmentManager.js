const baseUrl = "api/Alignment"

export const getAllAlignments = () =>{
    return fetch(baseUrl)
        .then(res => res.json())
}

export const getAlignmentById = (id) =>{
    return fetch(`${baseUrl}/${id}`)
        .then(res => res.json())
}