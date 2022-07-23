import { Form, FormGroup } from "reactstrap"
import { useEffect, useState } from "react"
import { useNavigate } from "react-router-dom"
import { getAllAlignments } from "../../modules/AlignmentManager"
import { addTrait } from "../../modules/TraitManager"
import { addCharacter } from "../../modules/CharacterManager"
import { getAllProfessions } from "../../modules/ProfessionManager"
import { getAllRaces } from "../../modules/RaceManager"
import { getCount, getTraitbyId, getRandom } from "../../modules/TraitManager"
import {Button} from "reactstrap"

export const NewCharacter = ({getLoggedInUser}) =>{

    const navigate = useNavigate()
    const [user, updateUser] = useState()
    const [alignments, setAlignments] = useState([])
    const [races, setRaces] = useState([])
    const [professions, setProfessions] = useState([])
    const [traits, updateTraits] = useState([])
    const [character, updateCharacter] = useState({})
    

    useEffect(()=>{
        getAllAlignments().then(res => setAlignments(res))
    },[])

    useEffect(()=>{
        getLoggedInUser().then(res => updateUser(res))
    },[])

    useEffect(()=>{
        getAllProfessions().then(res => setProfessions(res))
    },[])

    useEffect(()=>{
        getAllRaces().then(res => setRaces(res))
    },[])

    const generate = () =>{
        
        getRandom().then(res => updateTraits(res))
        

        
        
    }

    const saveCharacter = () =>{
        const newChar = {...character}
        newChar.userProfileId = user.id
        console.log(newChar)
        addCharacter(newChar).then((res) =>{
            const promises = []

            traits.forEach(t => promises.push(addTrait({traitId: t.id, characterId: res.id})))
            Promise.all(promises).then(() => navigate("/"))
                
        })}

    return (
        <div>
            <Form className="container-sm col-md-3">
        <fieldset>
            <FormGroup row>
                <label htmlFor="name">Character Name: </label>
                <input type="text" placeholder="character name" id="characterName" onChange={(e) => character.characterName = e.target.value}></input>
            </FormGroup>
            <FormGroup row>
            <label htmlFor="race-select">Character Race: </label>
                <select id="raceId" onChange={(e) => character.raceId = e.target.value}>
                    <option disabled={true} selected="selected">Choose a race</option>
                    {races.map(res => <option value={res.id}>{res.characterRace}</option>)}
                </select>
            </FormGroup>
            <FormGroup row>
            <label htmlFor="class-select">Character a class: </label>
                <select id="professionId" onChange={(e)=> character.professionId = e.target.value}>
                    <option disabled={true} selected="selected">Choose a class</option>
                    {professions.map(res => <option value={res.id}>{res.characterProfession}</option>)}
                </select>
            </FormGroup>
            <FormGroup row>
            <label htmlFor="race-select">Character an alignment: </label>
                <select id="alignmentId" onChange={(e)=> character.alignmentId =e.target.value}>
                    <option disabled={true} selected="selected">Choose an alignment</option>
                    {alignments.map(res => <option value={res.id}>{res.characterAlignment}</option>)}
                </select>
            </FormGroup>
            </fieldset>
            </Form>
            <FormGroup>
                <label>Traits:</label>
   
                {traits === null ? "" : traits.map(t => <p>{t.characterTrait}</p>)}
              
            </FormGroup>
            <FormGroup>
                {traits === null ? <><Button onClick={generate}>Generate Traits</Button></> : <><Button onClick={generate}>Generate Traits</Button><Button onClick={saveCharacter}>Save</Button></>}
            </FormGroup>
        
    
        </div>
    )
}