import { Form, FormGroup } from "reactstrap"
import { useEffect, useState } from "react"
import { useNavigate } from "react-router-dom"
import { getAllAlignments } from "../../modules/AlignmentManager"
import { addTrait } from "../../modules/TraitManager"
import { addCharacter } from "../../modules/CharacterManager"
import { getAllProfessions } from "../../modules/ProfessionManager"
import { getAllRaces } from "../../modules/RaceManager"
import { getFear, getFlaw, getStress } from "../../modules/TraitManager"
import { getCatalyst } from "../../modules/CatalystManager"
import { getDrive, getDriveFragment } from "../../modules/DriveManager"
import { getFragment, getQuirk, getTwoQuirks } from "../../modules/QuirkManager"
import {Button} from "reactstrap"

export const NewCharacter = ({getLoggedInUser}) =>{

    const quirkArr = []
    const navigate = useNavigate()
    const [user, updateUser] = useState()
    const [alignments, setAlignments] = useState([])
    const [races, setRaces] = useState([])
    const [professions, setProfessions] = useState([])
    const [character, updateCharacter] = useState({})
    const [fear, updateFear] = useState({})
    const [flaw, updateFlaw] = useState({})
    const [stress, updateStress] = useState({})
    const [traits, updateTraits] = useState(false)
    const [showQuirks, updateShowQuirks] = useState(false)
    const [showDrive, updateShowDrive] = useState(false)
    const [quirks, updateQuirks] = useState([])
    const [characterDrive, updateCharacterDrive] = useState()
    

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

    const generateTraits = () =>{
      
    getFear().then(res => updateFear(res))
    getFlaw().then(res => updateFlaw(res))
    getStress().then(res => updateStress(res))
    updateTraits(true)       
        
    }

    const generateQuirks = () =>{
        let fragment = {}
        let quirk = {}

        const promises = [getFragment().then(res => fragment=res),
            getTwoQuirks().then(res => quirk=res)]

        Promise.all(promises).then(() => {
        quirkArr.push(`${quirk[0].characterQuirk} ${fragment.fragmentTwo} ${quirk[1].characterQuirk}`)
        
        })
        
    }

    const generateDrive = () =>{
        let drive = {}
        let fragment = {}
        let catalyst = {}
        const promises = [getDrive().then(res => drive=res),
             getDriveFragment().then(res => fragment=res),
             getCatalyst().then(res => catalyst=res)]

              Promise.all(promises).then(() => {
                updateCharacterDrive(`${drive.driveTrait} ${fragment.fragmentTwo} ${catalyst.driveCatalyst}`)
            }).then(updateShowDrive(true))
    }



    const displayTraits = () =>{
        return (
            <>
                <h3>Traits</h3>
                <p value={flaw.Id}>Flaw: {flaw.flawCharacteristic}</p>
                <p value={fear.Id}>Afraid of: {fear.fearCharacteristic}</p>
                <p value={stress.Id}>When stressed your character is: {stress.stressedCharacteristic}</p>
            </>
        )
    }
    const selectNumberOfQuirks = () =>{

        for(let i = 0; i < 3; i++)
        {
            generateQuirks()
        }
        updateQuirks(quirkArr)
        updateShowQuirks(true)
    }

    const displayQuirks = () =>{
        return (
            <>
                <h3>Quirk(s)</h3>
                {quirks?.map((q) => <p>{q}</p>)}
            </>
        )
    }

    const displayDrive = () =>{
        return (
            <>
                <h3>Drive</h3>
                <p>{characterDrive}</p>
            </>
        )
    }

    const saveCharacter = () =>{
        if(character.characterName === null || character.characterProfession === null || character.characterAlignment === null || character.characterRace === null)
        {
            window.alert("Bro, make a character. What are you even doing?")
        }
        else{
            const newChar = {...character}
            newChar.userProfileId = user.id
            console.log(newChar)
            addCharacter(newChar)
            // addCharacter(newChar).then((res) =>{
            //     const promises = []
            //     traits.forEach(t => promises.push(addTrait({traitId: t.id, characterId: res.id})))
            //     Promise.all(promises).then(() => navigate("/"))
                    
            // })
        }
    }

    return (
        <div className="">
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
            <FormGroup>
                {traits ? displayTraits() : "" }
            </FormGroup>
            <FormGroup>
                {showDrive ? displayDrive(): ""}
                
            </FormGroup>
            <FormGroup>
                {showQuirks ? displayQuirks() : ""}
            </FormGroup>
            </fieldset>
            </Form>
            <FormGroup>
                <Button onClick={generateTraits}>Roll for Traits</Button>
                {traits ? <Button onClick={generateDrive}>Roll for Drive</Button> : ""}
                {traits && showDrive ? <Button onClick={selectNumberOfQuirks}>Roll for Quirks</Button>: ""}
            </FormGroup>
        
    
        </div>
    )
}