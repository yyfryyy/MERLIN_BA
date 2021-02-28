using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA.Persistence;
using Microsoft.MixedReality.Toolkit;
//using Microsoft.MixedReality.Toolkit.Experimental.Utilities;
using UnityEngine.XR.WSA;

public class WorldAnchorManagement : MonoBehaviour
{
   // public WorldAnchorManager worldAnchorManager;
    public string anchorName;
    WorldAnchor anchor;
    bool savedAnchor;

    WorldAnchorStore store;

    // Start is called before the first frame update
    void Awake()
    {
        WorldAnchorStore.GetAsync(StoreLoaded);
    }


    private void StoreLoaded(WorldAnchorStore store)
    {
        this.store = store;
        LoadAnchor();
    }

    public void LoadAnchor()
    {
        // Save data about holograms positioned by this world anchor
        this.savedAnchor = this.store.Load(anchorName, gameObject);
        if (!this.savedAnchor)
        {
            Debug.LogWarning("Couldnt load Anchor");
            // We didn't actually have the game root saved! We have to re-place our objects or start over
        }
    }

    public void SaveAnchor()
    {
        anchor = gameObject.AddComponent<WorldAnchor>();
        if (!this.savedAnchor) // only save this once
        {
            this.savedAnchor = this.store.Save(anchorName, anchor);
            if (!this.savedAnchor)
            {
                // Anchor failed to save to the store.
                // Handle errors here.
                Debug.LogError("Anchor failed to save to the store");
            }
        }
    }

    public void RemoveAnchor()
    {
        Destroy(anchor);
        if (savedAnchor)
        {
            savedAnchor = !this.store.Delete(anchorName);

            if (!this.savedAnchor)
            {
                Debug.LogWarning("Anchor Deleted");
            }
        }
        else
        {
            Debug.Log("No Anchor to delete");
        }


    }
}
