import { Form, FormGroup } from "reactstrap"
import { useEffect, useState } from "react"
import { useNavigate } from "react-router-dom"
import { getAllAlignments } from "../../modules/AlignmentManager"
import { addCharacter } from "../../modules/CharacterManager"
import { getAllProfessions } from "../../modules/ProfessionManager"
import { getAllRaces } from "../../modules/RaceManager"
import { getFear, getFlaw, getStress } from "../../modules/TraitManager"
import { getCatalyst } from "../../modules/CatalystManager"
import { getDrive, getDriveFragment } from "../../modules/DriveManager"
import { getFragment, getTwoQuirks } from "../../modules/QuirkManager"
import {Button} from "reactstrap"

export const NewCharacter = ({getLoggedInUser}) =>{

    const quirkArr = []
    const navigate = useNavigate()
    const [user, updateUser] = useState()
    const [alignments, setAlignments] = useState([])
    const [races, setRaces] = useState([])
    const [professions, setProfessions] = useState([])
    const [character, updateCharacter] = useState({})
    const [quirkSwitch, updateQuirkSwitch] = useState(false)
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
        updateQuirks(quirkArr)
        updateShowQuirks(true)
    },[quirkSwitch])

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

    const findProfession = () =>{
        let prof = professions.find(e => e.id === character.professionId)

        return prof.characterProfession.toLowerCase()
    }



    const displayTraits = (index) =>{

        const traitArr = [
        <div className="trait-div">
            <p value={flaw.id}>Flaw:</p>
            <p value={fear.id}>Afraid of:</p>
            <p value={stress.id}>When stressed your character is:</p>
        </div>,
                <div className="trait-div">
                    <p value={flaw.id}>Flaw: {flaw.flawCharacteristic}</p>
                    <p value={fear.id}>Afraid of: {fear.fearCharacteristic}</p>
                    <p value={stress.id}>When stressed your character is: {stress.stressedCharacteristic}</p>
                </div>
        ]
        return (
            traitArr[index]
        )
    }
    const selectNumberOfQuirks = () =>{

        for(let i = 0; i < 3; i++)
        {
            generateQuirks()
            updateQuirks(quirkArr)
        }
        
        updateShowQuirks(true)
        updateQuirkSwitch(quirkSwitch)
    }

    const displayQuirks = () =>{

        const quirkArr = []
        return (
            <>
                {quirks?.map((q) => <p>{q}</p>)}
            </>
        )
    }

    const displayDrive = (index) =>{

        const driveArr = [<p>Your character is driven by a need to:</p>, <p>Your character is driven by a need to: {characterDrive}</p>]
        return (
            
                driveArr[index]
            
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
            newChar.fearId = fear.id
            newChar.stressId = stress.id
            newChar.flawId = flaw.id
            newChar.characterDrive = characterDrive
            newChar.quirkOne = quirks[0]
            newChar.quirkTwo = quirks[1]
            newChar.quirkThree = quirks[2]
            addCharacter(newChar).then(() => navigate("/"))

        }
    }

    return (
       <div className="new-char-sheet">
         <div className="new-char-form-container container-md-sm row">
            <div class="character-img col-md-3">
                {/* <img src={`/images/monk-symbol.svg`}/> */}
            </div>
        <Form className="col-md-3 m-2">
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
                <h5>Roll for:</h5>
            {character.traitId  && character.raceId  && character.alignmentId  ? <Button disabled={true}>Traits</Button> : <Button onClick={generateTraits} className="m-1">Traits</Button>}
            {traits ? <Button onClick={generateDrive}>Drive</Button> : ""}
            {traits && showDrive ? <Button onClick={selectNumberOfQuirks} className="m-1">Quirks</Button>: ""}
            </FormGroup>
            </fieldset>
            </Form>
            <div className="trait-drive-quirk-div col">
            <FormGroup className="traits-group">
                <h4>Traits</h4>
                {traits ? displayTraits(1) : displayTraits(0) }  
            </FormGroup>
            <FormGroup className="drive-group">
                <h4>Drive</h4>
                {showDrive ? displayDrive(1): displayDrive(0)}  
            </FormGroup>
            <FormGroup className="quirks-group">
                <h4>Quirks</h4>
                {showQuirks ? displayQuirks() : ""}      
            </FormGroup>
            <FormGroup>

                {traits && showDrive && showQuirks ? <Button onClick={saveCharacter}>Save</Button> : <Button disabled={true}>Save</Button>}
            </FormGroup>
            </div>
        </div>
       </div>
    )
}