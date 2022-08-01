import { Button, Modal, ModalBody, ModalHeader, ModalFooter } from "reactstrap"
import {BsFillPencilFill} from 'react-icons/bs'



export const CharacterDetails = ({character, isOpen, updateIsOpen, updateEdit, edit, handleKeyPress, handleDelete}) =>{

    return(
        <>
        <Modal isOpen={isOpen} backdrop={true} toggle={()=> updateIsOpen(!isOpen)} className="container-sm">

        <ModalHeader className="container-sm"><div className="row">
            {edit ? <input type="text" id="characterName" autoFocus className="col-md-auto" defaultValue={character?.characterName} onKeyDown={handleKeyPress} onChange={(e) => character.characterName = e.target.value}/> : <div className="col-md-auto">{character?.characterName}</div>}
            {edit ? "" : <div className="col-md-auto" style={{cursor:'pointer'}} onClick={()=> updateEdit(!edit)}><BsFillPencilFill/></div>}</div>
        </ModalHeader>
        <ModalBody>
            <p>Race: {character?.characterRace?.characterRace}</p>
            <p>Class: {character?.characterProfession?.characterProfession}</p>
            <p>Alignment: {character?.characterAlignment?.characterAlignment} </p>
            <h3>Flaws</h3>
            <p>Personality: {character?.flaw?.flawCharacteristic}</p>
            <p>Is afraid of: {character?.fear?.fearCharacteristic}</p>
            <p>When stressed: {character?.stress?.stressedCharacteristic}</p>
            <h3>Drive</h3>
            <p>Driven by: {character.characterDrive}</p>
            <h3>Quirks</h3>
            <p>{character.quirkOne}</p>
            <p>{character.quirkTwo}</p>
            <p>{character.quirkThree}</p>

        </ModalBody>
        
        <ModalFooter><Button className="btn btn-danger" onClick={handleDelete}>Delete</Button></ModalFooter>
        </Modal>
        </>
    )
}