const quirkUrl = "api/Quirk"
const fragmentUrl = "api/QuirkFragment"

export const getQuirk = () =>{
    return fetch(quirkUrl).then(res => res.json())
}

export const getTwoQuirks = () =>{
    return fetch(`${quirkUrl}/GetTwoRandom`).then(res => res.json())
}

export const getFragment = () =>{
    return fetch(fragmentUrl).then(res => res.json())
}

export const getMultiple = (index) =>{
    return fetch(`${quirlUrl}/GetMultiple/${index}`).then(res => res.json())
}