import { Button, Modal, ModalBody, ModalHeader, ModalFooter } from "reactstrap"
import {BsFillPencilFill} from 'react-icons/bs'



export const CharacterDetails = ({character, isOpen, updateIsOpen, updateEdit, edit, handleKeyPress}) =>{

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
            <p>Traits: {character?.traits.map(res => <p>{res.characterTrait}</p>)}</p>         
        </ModalBody>
        
        <ModalFooter><Button className="btn btn-danger">Delete</Button></ModalFooter>
        </Modal>
        </>
    )
}