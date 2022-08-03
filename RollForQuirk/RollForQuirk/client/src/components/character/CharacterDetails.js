import { Button, Modal, ModalBody, ModalHeader, ModalFooter, CardImg, CardImgOverlay } from "reactstrap"
import {BsFillPencilFill} from 'react-icons/bs'



export const CharacterDetails = ({character, isOpen, updateIsOpen, updateEdit, edit, handleKeyPress, handleDelete}) =>{

  const imageSize = {
    maxHeight: 200,
    maxWidth: 300
}

    return (
      <>
        <Modal isOpen={isOpen} backdrop={true} toggle={() => updateIsOpen(!isOpen)} className="character-modal container-sm">
          <ModalHeader><h3>{character.characterName}</h3></ModalHeader>          

          <ModalBody>
            <div>
            <p><strong>Race: </strong> {character.characterRace.characterRace}</p>
            <p><strong>Class: </strong> {character.characterProfession.characterProfession}</p>
            <p><strong>Alignment: </strong>{character.characterAlignment.characterAlignment}</p>
            </div>
            <div className="border-div"></div>
            <div id="modal-trait-div" className="modal-div">
            <h4>Traits</h4>
              <p><strong>Flaw: </strong>{character.flaw.flawCharacteristic}</p>
              <p><strong>Afraid of: </strong>{character.fear.fearCharacteristic}</p>
              <p><strong>When stressed your character is: </strong>{character.stress.stressedCharacteristic}</p>
            </div>
            <div className="border-div"></div>
            <div id="modal-drive-div" className="modal-div">
              <h4>Drive</h4>
              <p><strong>Your character is driven by a need to: </strong>{character.characterDrive}</p>
            </div>
            <div className="border-div"></div>
            <div id="modal-quirk-div" className="modal-div" >
              <h4>Quirks</h4>
              <ul>
                <li>{character.quirkOne}</li>
                <li>{character.quirkTwo}</li>
                <li>{character.quirkThree}</li>
              </ul>
            </div>
            <div className="border-div"></div>
          </ModalBody>
          <div className="modal-btn-div">
          <Button className="btn btn-danger" onClick={handleDelete}>Delete</Button>
          </div>
          
          
        </Modal>
      </>
    );
}